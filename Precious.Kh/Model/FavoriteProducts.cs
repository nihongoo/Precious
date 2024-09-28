using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.Kh.Model
{
	public class FavoriteProducts
	{
		/// <summary>
		/// ID sản phẩm
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		public Guid IDProduct { get; set; }

		/// <summary>
		/// ID khách hàng
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		public Guid IDCustomer { get; set; }

		public int? Status { get; set; }

		public virtual Customer? Customer { get; set; }
		public virtual Product? Product { get; set; }
	}
}
