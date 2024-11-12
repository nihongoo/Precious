using Precious.core.Extention;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.Kh.Model
{
	public class Product
	{
		public Guid IDProduct { get; set; }

		/// <summary>
		/// Tên sản phẩm
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		public string Name { get; set; }

		/// <summary>
		/// Mô tả
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Mã sản phẩm
		/// </summary>
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
		/// ngày tạo sản phẩm
		/// </summary>
		[FutureDate]		
		public DateTime CreateTime { get; set; }

		public int Status { get; set; }

		//public Guid IDSize { get; set; }
		public Guid IDBrand { get; set; }
		public Guid IDCategory { get; set; }
		public Guid IDMeterial { get; set; }
		public Guid IDTagetCustomer { get; set; }

		//public virtual Size Size { get; set; }
		public virtual Brand? Brand { get; set; }
		public virtual Category? Category { get; set; }
		public virtual Meterial? Meterial { get; set; }
		public virtual TagetCustomers? TagetCustomer { get; set; }
		public virtual FavoriteProducts? FavoriteProducts { get; set;}
		public virtual ICollection<ProductDetail>? ProductDetail { get; set; }
	}
}
