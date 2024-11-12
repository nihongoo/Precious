using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.core.Models
{
	public class BillDetailViewModel
	{
		public Guid IDBillDetail { get; set; }

		/// <summary>
		/// số lượng
		/// </summary>
		[Required(ErrorMessage = "Không được để trống")]
		[Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0.")]
		public int Quantity { get; set; }

		/// <summary>
		/// giá
		/// </summary>
		[Required(ErrorMessage = "Không được để trống")]
		[Range(0, double.MaxValue, ErrorMessage = "Giá phải luôn dương.")]
		public double Price { get; set; }


		public int Status { get; set; }

		public Guid IDBill { get; set; }
		public Guid IDProductDetail { get; set; }
	}
}
