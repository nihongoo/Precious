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
	public class ProductDetailService : IProductDetailService
	{
		private readonly AppDbContext _dbContext;
		public ProductDetailService(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<List<ProductDetail>> GetAll(Guid productId)
		{
			return await _dbContext.ProductDetail.Where(k => k.IDProduct == productId).ToListAsync();
		}

		public async Task<(bool k, string msg)> Update(ProductDetailViewModel detail)
		{
			try
			{
				var product = await _dbContext.ProductDetail.FirstOrDefaultAsync(k => k.ProductDetailCode == detail.ProductDetailCode);

				if (product == null)
				{
					return (false, "Không tìm thấy sản phẩm chi tiết.");
				}

				product.Quantity = detail.Quantity;
				product.GiaNhap = detail.GiaNhap;
				product.GiaBan = detail.GiaBan;
				product.IDColor = detail.IDColor;
				product.IDSale = detail.IDSale;
				product.IDSize = detail.IDSize;

				await _dbContext.SaveChangesAsync();

				return (true, "Cập nhật sản phẩm chi tiết thành công.");
			}
			catch (Exception ex)
			{
				return (false, $"Lỗi: {ex.Message}");
			}
		}

	}
}
