using Precious.core.Extention;
using Precious.Kh.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.core.Models
{
	public class ProductViewModel
	{
		#region Product
		/// <summary>
		/// Tên sản phẩm
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		public string Name { get; set; }

		/// <summary>
		/// Mô tả
		/// </summary>
		public string? Description { get; set; }

		/// <summary>
		/// Mã sản phẩm
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		public string ProductCode { get; set; }

		/// <summary>
		/// link ảnh sản phẩm/ nếu không thêm thì để 1 ảnh defaul
		/// </summary>
		public string? Image { get; set; }

		/// <summary>
		/// thời gian bảo hành
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		public string ThoiGianBaoHanh { get; set; }

		/// <summary>
		/// Chất liệu
		/// </summary>
		public string? ChatLieu { get; set; }

		/// <summary>
		/// ngày tạo sản phẩm
		/// </summary>
		[FutureDate]
		public DateTime CreateTime { get; set; }

		public int Status { get; set; }
		#endregion
		#region Brand
		[Required(ErrorMessage = "Không được để trống.")]
		public Guid IDBrand { get; set; }
		#endregion
		#region Category
		[Required(ErrorMessage = "Không được để trống.")]
		public Guid IDCategory { get; set; }
		#endregion
		#region TagetCustomer
		[Required(ErrorMessage = "Không được để trống.")]
		public Guid IDTagetCustomer { get; set; }
		#endregion

		//public List<ProductDetailViewModel> productDetails { get; set; }
	}
}
