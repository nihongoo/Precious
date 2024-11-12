using CloudinaryDotNet;
using Microsoft.EntityFrameworkCore;
using Precious.core.IService;
using Precious.core.Models;
using Precious.Kh.Model;
using ZXing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ZXing.QrCode;
using CloudinaryDotNet.Actions;
using System.Text.RegularExpressions;

namespace Precious.core.Service
{
	public class ProductService : IProductService
	{
		private readonly AppDbContext _dbContext;
		private readonly Cloudinary _cloudinary;
		public ProductService(AppDbContext dbContext, Cloudinary cloudinary)
		{
			_dbContext = dbContext;
			_cloudinary = cloudinary;
		}

		public async Task<(bool k, string msg)> AddProduct(ProductViewModel product, List<ProductDetailViewModel> productDetails)
		{
			var brands = await GetBrands();
			var category = await GetCategories();
			var tagetcustomer = await GetTagetCustomers();
			var color = await GetColors();
			var size = await GetSizes();
			var sale = await GetSales();
			try
			{
				if (product == null || productDetails == null || !productDetails.Any())
				{
					return (false, "Sản phẩm hoặc sản phẩm chi tiết không hợp lệ.");
				}

				if (!brands.Any(k => k.IDBrand == product.IDBrand)) return (false, "IDBrand không tồn tại");
				if (!category.Any(k => k.IDCategory == product.IDCategory)) return (false, "IDCategory không tồn tại");
				if (!tagetcustomer.Any(k => k.IDTagetCustomer == product.IDTagetCustomer)) return (false, "IDTagetCustomer không tồn tại");


				var imgUrl = await GetAnImage(product.Image);
				var generatedProductCode = GenerateSerialCode();
				product.ProductCode = generatedProductCode;

				var item = new Product()
				{
					IDProduct = Guid.NewGuid(),
					Name = product.Name,
					Description = product.Description,
					ProductCode = generatedProductCode,
					Image = imgUrl,
					ThoiGianBaoHanh = product.ThoiGianBaoHanh,
					CreateTime = DateTime.Now,
					Status = 1,
					IDBrand = product.IDBrand,
					IDCategory = product.IDCategory,
					IDMeterial = product.IDMeterial,
					IDTagetCustomer = product.IDTagetCustomer,
					ProductDetail = new List<ProductDetail>()
				};

				foreach (var dettail in productDetails)
				{
					if (!color.Any(k => k.IDColor == dettail.IDColor)) return (false, "IDColor không tồn tại.");
					if (!size.Any(k => k.IDSize == dettail.IDSize)) return (false, "IDSize không tồn tại.");

					var generatedDetailCode = GenerateSerialCode();
					dettail.ProductDetailCode = generatedDetailCode;

					item.ProductDetail.Add(new ProductDetail
					{
						IDProductDetail = Guid.NewGuid(),
						ProductDetailCode = generatedDetailCode,
						Quantity = dettail.Quantity,
						GiaNhap = dettail.GiaNhap,
						GiaBan = dettail.GiaBan,
						CreateTime = DateTime.Now,
						Status = 1,
						IDProduct = item.IDProduct,
						IDColor = dettail.IDColor,
						IDSale = dettail.IDSale,
						IDSize = dettail.IDSize,
					});
				}

				await _dbContext.Product.AddAsync(item);
				await _dbContext.SaveChangesAsync();

				return (true, "Tạo sản phẩm thành công.");

			}
			catch (Exception ex)
			{
				return (false, "Đã có lỗi: " + ex.Message);
			}
		}

		public async Task<List<Brand>> GetBrands()
		{
			return await _dbContext.Brand.ToListAsync();
		}
		public async Task<List<Category>> GetCategories()
		{
			return await _dbContext.Category.ToListAsync();
		}
		public async Task<List<TagetCustomers>> GetTagetCustomers()
		{
			return await _dbContext.TagetCustomers.ToListAsync();
		}
		public async Task<List<Precious.Kh.Model.Color>> GetColors()
		{
			return await _dbContext.Color.ToListAsync();
		}
		public async Task<List<Precious.Kh.Model.Size>> GetSizes()
		{
			return await _dbContext.Size.ToListAsync();
		}
		public async Task<List<Sale>> GetSales()
		{
			return await _dbContext.Sale.ToListAsync();
		}

		/// <summary>
		/// lấy link ảnh
		/// </summary>
		/// <param name="publicId"></param>
		/// <returns></returns>
		public async Task<string> GetAnImage(string publicId)
		{
			string defaultUrl = "https://res.cloudinary.com/dtlxhfejw/image/upload/v1728380665/notfound_lgqmju.png";
			var res = _cloudinary.GetResource(publicId);
			if (res.Url != null) return res.Url;
			else return defaultUrl;
		}
		/// <summary>
		/// tạo mã cho sản phẩm
		/// </summary>
		/// <returns></returns>
		private string GenerateSerialCode()
		{
			return Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper();
		}
		private Bitmap GenerateBarcode(string code)
		{
			var barcodeWriter = new BarcodeWriter<Bitmap>
			{
				Format = BarcodeFormat.CODE_128,
				Options = new ZXing.Common.EncodingOptions
				{
					Width = 300,
					Height = 100
				}
			};
			return barcodeWriter.Write(code);
		}

		public async Task<(bool k, string msg)> AddToCart(Guid productDetailId, int quantity, Guid UserID)
		{
			try
			{
				var product = await _dbContext.ProductDetail.FirstOrDefaultAsync(k => k.IDProductDetail == productDetailId);
				if (quantity > product.Quantity) return (false, "Không đủ số lượng sản phẩm");
				var CartItem = await _dbContext.CartDetail.FirstOrDefaultAsync(k => k.IDProductDetail == productDetailId && k.IDCart == UserID);
				if (CartItem == null)
				{
					CartDetail cartDetail = new CartDetail()
					{
						IDCartDetail = Guid.NewGuid(),
						IDProductDetail = productDetailId,
						IDCart = UserID,
						Quantity = quantity,
						Price = product.GiaBan,
						Status = 0
					};
					_dbContext.CartDetail.Add(cartDetail);
					_dbContext.SaveChangesAsync();
				}
				else
				{
					CartItem.Quantity = CartItem.Quantity + quantity;
					_dbContext.CartDetail.Update(CartItem);
					_dbContext.SaveChangesAsync();
				}
				return (true, "Thêm vào giỏ hàng thành công");
			}
			catch (Exception ex)
			{
				return (false, "Đã có lỗi: " + ex.Message);
			}
		}

		public async Task<(bool k, string msg)> DeleteImg(Guid id)
		{
			var product = await _dbContext.Product.FindAsync(id);
			var publicId = ExtractPublicIdFromUrl(product.Image);
			
			if (string.IsNullOrEmpty(publicId) || publicId == "notfound_lgqmju")
			{
				return (true, "Lỗi xóa ảnh");
			}
			else
			{
				var result = await _cloudinary.DeleteResourcesAsync(publicId);
				return (true, "Xóa thành công");
			}
		}
		private string ExtractPublicIdFromUrl(string imageUrl)
		{
			// Regex để tách public_id
			var regex = new Regex(@"image\/upload\/[^\/]+\/([^\.]+)", RegexOptions.IgnoreCase);
			var match = regex.Match(imageUrl);

			if (match.Success)
			{
				return match.Groups[1].Value;
			}

			return string.Empty;
		}
	}
}
