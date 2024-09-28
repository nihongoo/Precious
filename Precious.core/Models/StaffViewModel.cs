using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.core.Models
{
	public class StaffViewModel
	{
		public Guid IdStaff { get; set; }

		/// <summary>
		/// Mã nhân viên
		/// </summary>
		public string StaffCode { get; set; }

		/// <summary>
		/// Họ và tên
		/// </summary>
		public string StaffName { get; set; }

		/// <summary>
		/// Email
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// số điện thoại +84/ 0
		/// </summary>
		public string PhoneNumber { get; set; }

		/// <summary>
		///địa chỉ 
		/// </summary>
		public string Address { get; set; }

		/// <summary>
		/// ngày vào làm
		/// </summary>
		public DateTime DateJoin { get; set; }

		/// <summary>
		/// trạng thái
		/// </summary>
		public int Status { get; set; }

		public Guid IDUser { get; set; }

		public string UserName { get; set; }

		/// <summary>
		/// Password
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// Role
		/// </summary>
		public string Role { get; set; }
	}
}
