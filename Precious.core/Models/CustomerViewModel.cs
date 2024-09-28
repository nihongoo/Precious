using Precious.core.Extention;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.core.Models
{
	public class CustomerViewModel
	{
		public Guid IDCustomer { get; set; }

		/// <summary>
		///Họ và tên 
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Giới tính
		/// </summary>
		public int GioiTinh { get; set; }

		/// <summary>
		/// Ngày sinh
		/// </summary>
		public DateTime BirthDay { get; set; }

		/// <summary>
		/// Số điện thoại +84/ 0
		/// </summary>
		public string PhoneNumber { get; set; }

		/// <summary>
		/// Email
		/// </summary>
		public string Email { get; set; }

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
		public string? Role { get; set; }
	}
}
