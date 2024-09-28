using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.Kh.Model
{
	public class Category
	{
		public Guid IDCategory { get; set; }

		/// <summary>
		/// Tên loại
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		[MaxLength(100, ErrorMessage ="Tối đa 100 ký tự.")]
		public string Name { get; set; }

		public int Status { get; set; }

		public virtual ICollection<Product>? Products { get; set; }
	}
}
