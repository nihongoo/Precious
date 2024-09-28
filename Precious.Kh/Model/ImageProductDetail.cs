using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.Kh.Model
{
	public class ImageProductDetail
	{
		public Guid IDImageProductDetail { get; set; }

		/// <summary>
		/// link ảnh sản phẩm chi tiết
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		public string ImgUrl { get; set; }

		public Guid IDProductDetail { get; set; }

		public virtual ProductDetail? ProductDetail { get; set; }
	}
}
