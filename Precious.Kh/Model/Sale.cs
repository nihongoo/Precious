using Precious.core.Extention;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.Kh.Model
{
	public class Sale
	{
		public Guid IDSale { get; set; }

		/// <summary>
		/// Mã khuyến mại
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		public string SaleCode { get; set; }

		/// <summary>
		/// tên đợt khuyến mại
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		public string Name { get; set; }

		/// <summary>
		/// giá trị khuyến mại
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		[Range(0, int.MaxValue, ErrorMessage ="Giá trị khuyến mại không được âm.")]
		public double Value { get; set; }

		/// <summary>
		/// ngày bắt đầu khuyến mại
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		public DateTime StartDay { get; set; }

		/// <summary>
		/// ngày kết thúc khuyến mại không được nhỏ hơn ngày hiện tại
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		[FutureDate]
		public DateTime EndDay { get; set; }

		/// <summary>
		/// mô tả
		/// </summary>
		public string Description { get; set; }

		public int Status { get; set; }

		public virtual ICollection<ProductDetail>? ProductDetails { get; set; }
	}
}
