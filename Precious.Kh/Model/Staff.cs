using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.Kh.Model
{
	public class Staff
	{
		public Guid IdStaff { get; set; }

		/// <summary>
		/// Mã nhân viên
		/// </summary>
		[Required(ErrorMessage ="Không được để trống")]
		[RegularExpression(@"^SC\d{6}$", ErrorMessage = "Mã nhân viên phải có định dạng SC + 6 chữ số.")]
		public string StaffCode { get; set; }

		/// <summary>
		/// Họ và tên
		/// </summary>
		[Required(ErrorMessage = "Không được để trống")]		
		public string StaffName { get; set; }

		/// <summary>
		/// Email
		/// </summary>
		[Required(ErrorMessage = "Không được để trống")]
		[EmailAddress]
		public string Email { get; set; }

		/// <summary>
		/// số điện thoại +84/ 0
		/// </summary>
		[Required(ErrorMessage = "Không được để trống")]
		[RegularExpression("^(?:\\+84|0)(?:3[2-9]|5[6|8|9]|7[0|6-9]|8[1-5]|9[0-4|6-9])[0-9]{7}$",ErrorMessage = "Số điện thoại sai định dạng")]
		public string PhoneNumber { get; set; }

		 /// <summary>
		 ///địa chỉ 
		 /// </summary>
		[Required(ErrorMessage = "Không được để trống")]
		public string Address { get; set; }

		/// <summary>
		/// ngày vào làm
		/// </summary>
		[Required(ErrorMessage = "Không được để trống")]
		public DateTime DateJoin { get; set; }

		/// <summary>
		/// trạng thái
		/// </summary>
		public int Status { get; set; }

		public Guid IDUser { get; set; }

		public virtual ICollection<Bill>? Bills { get; set; }
		public virtual Account? Account { get; set; }
	}
}
