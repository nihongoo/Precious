using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.Kh.Model
{
	public class Size
	{
		public Guid IDSize { get; set; }

		/// <summary>
		/// Tên size
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		public string Name { get; set; }

		public int Status { get; set; }

		public virtual ICollection<ProductDetail>? ProductDetails { get; set; }
	}
}
