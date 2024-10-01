using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.core.Models
{
	public class ProductDetailViewModel
	{
		#region ProductDetail
		[Required(ErrorMessage = "Không được để trống.")]
		public string ProductDetailCode { get; set; }

		/// <summary>
		/// Số lượng trong kho/ Check nhập kho ko đc = 0
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		[Range(0, int.MaxValue, ErrorMessage = "Số lượng không được âm.")]
		public int Quantity { get; set; }

		/// <summary>
		/// Giá nhập
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		[Range(0, double.MaxValue, ErrorMessage = "Giá nhập không được âm.")]
		public double GiaNhap { get; set; }

		/// <summary>
		/// Giá bán
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		[Range(0, double.MaxValue, ErrorMessage = "Giá bán không được âm.")]
		public double GiaBan { get; set; }
		#endregion
		#region Color
		[Required(ErrorMessage = "Không được để trống.")]
		public Guid IDColor { get; set; }
		#endregion
		#region Sale
		public Guid? IDSale { get; set; }
		#endregion
		#region Size
		[Required(ErrorMessage = "Không được để trống.")]
		public Guid IDSize { get; set; }
		#endregion
	}
}
