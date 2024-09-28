using Precious.core.Extention;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.core.Models
{
	public class VoucherViewModel
	{
		public Guid IDVoucher { get; set; }

		/// <summary>
		/// Mã voucher
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		public string VoucherCode { get; set; }

		[Required(ErrorMessage = "Không được để trống.")]
		[Range(0, int.MaxValue, ErrorMessage = "Giá trị voucher không được âm.")]
		public int Value { get; set; }

		/// <summary>
		/// số lượng voucher
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		[Range(0, int.MaxValue, ErrorMessage = "Không được nhập số lượng âm.")]
		public int Quantity { get; set; }

		/// <summary>
		/// Ngày bắt đầu có thể áp dụng voucher
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		public DateTime StartDay { get; set; }

		/// <summary>
		/// Ngày kết thúc voucher
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		[FutureDate]
		public DateTime EndDay { get; set; }

		public int Status { get; set; }
	}
}
