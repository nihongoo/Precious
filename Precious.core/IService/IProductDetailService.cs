using Precious.core.Models;
using Precious.Kh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.core.IService
{
	public interface IProductDetailService
	{
		Task<List<ProductDetail>> GetAll(Guid productId);
		Task<(bool k, string msg)> Update(ProductDetailViewModel detail);
	}
}
