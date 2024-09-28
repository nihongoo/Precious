using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.Kh.Model
{
	public class Account
	{
		/// <summary>
		/// Id User
		/// </summary>
		public Guid IDUser { get; set; }

		/// <summary>
		/// User Name
		/// </summary>
		[Required(ErrorMessage = "Không được để trống")]
		[MaxLength(128,ErrorMessage ="Tối đa 128 ký tự")]
		public string UserName { get; set; }

		/// <summary>
		/// Password
		/// </summary>
		[Required(ErrorMessage ="Không được để trống")]
		[MaxLength(64, ErrorMessage ="Tối đa 64 ký tự")]
		public string Password { get; set; }

		/// <summary>
		/// Role
		/// </summary>
		public string Role { get; set; }

		public Guid? IDStaff { get; set; }
		public Guid? IDCustomer { get; set; }

		public virtual Staff? Staff { get; set; }
		public virtual Customer? Customer { get; set; }
	}
}
