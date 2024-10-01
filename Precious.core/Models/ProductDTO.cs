using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.core.Models
{
	public class ProductDTO
	{
		public ProductViewModel Product { get; set; }
		public List<ProductDetailViewModel> ProductDetails { get; set; }
	}
}
