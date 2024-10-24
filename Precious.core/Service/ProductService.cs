using CloudinaryDotNet;
using Microsoft.EntityFrameworkCore;
using Precious.core.IService;
using Precious.core.Models;
using Precious.Kh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

				var item = new Product()
				{
					IDProduct = Guid.NewGuid(),
					Name = product.Name,
					Description = product.Description,
					ProductCode = product.ProductCode,
					Image = imgUrl,
					ThoiGianBaoHanh = product.ThoiGianBaoHanh,
					ChatLieu = product.ChatLieu,
					CreateTime = DateTime.Now,
					Status = 1,
					IDBrand = product.IDBrand,
					IDCategory = product.IDCategory,
					IDTagetCustomer = product.IDTagetCustomer,
					ProductDetail = new List<ProductDetail>()
				};

				foreach (var dettail in productDetails)
				{
					if (!color.Any(k => k.IDColor == dettail.IDColor)) return (false, "IDColor không tồn tại.");
					if (!size.Any(k => k.IDSize == dettail.IDSize)) return (false, "IDSize không tồn tại.");
					item.ProductDetail.Add(new ProductDetail
					{
						IDProductDetail = Guid.NewGuid(),
						ProductDetailCode = dettail.ProductDetailCode,
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
		public async Task<List<Color>> GetColors()
		{
			return await _dbContext.Color.ToListAsync();
		}
		public async Task<List<Size>> GetSizes()
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
			var res = _cloudinary.GetResource(publicId);
			return res.Url;
		}
	}
}
