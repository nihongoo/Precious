using Precious.core.Extention;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.Kh.Model
{
	public class ProductDetail
	{
		public Guid IDProductDetail { get; set; }

		/// <summary>
		/// Mã sản phẩm chi tiết
		/// </summary>
		public string ProductDetailCode { get; set; }

		/// <summary>
		/// Số lượng trong kho/ Check nhập kho ko đc = 0
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		[Range(0, int.MaxValue,ErrorMessage ="Số lượng không được âm.")]
		public int Quantity { get; set; }

		/// <summary>
		/// Giá nhập
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		[Range(0,double.MaxValue, ErrorMessage ="Giá nhập không được âm.")]
		public double GiaNhap { get; set; }

		/// <summary>
		/// Giá bán
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		[Range(0, double.MaxValue, ErrorMessage ="Giá bán không được âm.")]
		public double GiaBan { get; set; }

		/// <summary>
		/// Ngày nhập
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		[FutureDate]
		public DateTime CreateTime { get; set; }

		public int Status { get; set; }

		public Guid IDProduct { get; set; }
		public Guid IDColor { get; set; }
		public Guid? IDSale { get; set; }
		public Guid IDSize { get; set; }

		public virtual Product? Product { get; set; }
		public virtual Color? Color { get; set; }
		public virtual Sale? Sale { get; set; }
		public virtual Size? Size { get; set; }
		public virtual ICollection<ImageProductDetail>? ImageProductDetail { get; set; }
		public virtual ICollection<CartDetail>? CartDetails { get; set; }
		public virtual ICollection<BillDetail>? BillDetails { get; set;}
	}
}
