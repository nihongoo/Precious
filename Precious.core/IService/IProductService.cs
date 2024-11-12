using Precious.core.Models;
using Precious.Kh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.core.IService
{
	public interface IProductService
	{
		Task<(bool k, string msg)> AddProduct(ProductViewModel product, List<ProductDetailViewModel> productDetails);
		Task<(bool k, string msg)> AddToCart(Guid productDetailId, int quantity, Guid UserID);
	}
}
