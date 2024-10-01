using Precious.core.Models;
using Precious.Kh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.core.IService
{
	interface IProductService
	{
		Task<(bool k, string msg)> AddProduct(ProductViewModel product, List<ProductDetailViewModel> productDetails);
	}
}
