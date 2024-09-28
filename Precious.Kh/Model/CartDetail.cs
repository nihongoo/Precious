﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.Kh.Model
{
	public class CartDetail
	{
		public Guid IDCartDetail { get; set; }

		/// <summary>
		/// Số lượng phải luôn dương
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		[Range(1, int.MaxValue, ErrorMessage ="Số lượng phải lớn hơn 0.")]
		public int Quantity { get; set; }

		/// <summary>
		/// Giá có thể thay đổi
		/// </summary>
		[Required(ErrorMessage = "Không được để trống.")]
		[Range(0, double.MaxValue, ErrorMessage ="Giá phải luôn dương.")]		
		public double Price { get; set; }

		public int Status { get; set; }

		public Guid IDCart { get; set; }
		public Guid IDProductDetail { get; set; }

		public virtual Cart? Cart { get; set; }
		public virtual ProductDetail? ProductDetail { get; set; }
	}
}
