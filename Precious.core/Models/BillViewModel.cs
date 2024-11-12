using Precious.core.Extention;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.core.Models
{
	public class BillViewModel
	{
		public Guid IDBill { get; set; }

		/// <summary>
		/// Mã hóa đơn
		/// </summary>
		[Required(ErrorMessage = "Không được để trống")]
		public string BillCode { get; set; }

		/// <summary>
		/// tổng tiền
		/// </summary>
		public double Total { get; set; }

		/// <summary>
		/// Ngày tạo hóa đơn
		/// </summary>		
		[Required(ErrorMessage = "Không được để trống")]
		public DateTime NgayTao { get; set; }

		/// <summary>
		/// Ngày giao hàng, FutureDate được override trong namespace Precious.core.Extention
		/// </summary>
		[Required(ErrorMessage = "Không được để trống")]
		[FutureDate]
		public DateTime NgayGiaoHang { get; set; }

		/// <summary>
		/// Ngày nhận hàng
		/// </summary>
		[Required(ErrorMessage = "Không được để trống")]
		[FutureDate]
		public DateTime NgayNhanHang { get; set; }

		/// <summary>
		/// Ngày thanh toán
		/// </summary>
		public DateTime NgayThanhToan { get; set; }

		/// <summary>
		/// Trạng thái
		/// Case:
		/// 1:$Tạo mới, Đơn mới tạo và chưa được xử lý
		/// 2:$Xác nhận, Xác nhận đơn hàng và sẽ được xử lý
		/// 3:$Đang xử lý, Đang đóng gói hoặc đang chuẩn bị
		/// 4:$Đã giao hàng, Hàng đã được đưa ra khỏi kho
		/// 5:$Đang giao hàng, Hàng đang được giao đến cho khách
		/// 6:$Hoàn tất, Đơn hàng đã giao đến nơi
		/// 7:$Đã hủy, Đơn hàng bị hủy bởi khách hoặc shop
		/// 8:$Trả hàng, Khách yêu cầu trả hàng
		/// 9:$Chờ thanh toán, Đơn hàng hoàn tất nhưng chưa thanh toán
		/// 10:$Đã thanh toán, Khách đã thanh toán đơn
		/// </summary>
		public int Status { get; set; }

		/// <summary>
		/// thông tin khách hàng
		/// </summary>
		[Required(ErrorMessage = "Không được để trống")]
		public string TenNguoiNhan { get; set; }

		[Required(ErrorMessage = "Không được để trống")]
		public string EmailNguoiNhan { get; set; }

		[Required(ErrorMessage = "Không được để trống")]
		public string SDTNguoiNhan { get; set; }

		[Required(ErrorMessage = "Không được để trống")]
		public string DiaChiNguoiNhan { get; set; }

		/// <summary>
		/// số tiền khách đã thanh toán
		/// </summary>
		public double KhachThanhToan { get; set; }

		/// <summary>
		/// giảm giá = giá khuyến mãi - voucher(có lim)
		/// </summary>
		public double GiamGia { get; set; }

		/// <summary>
		/// mã giảm giá nếu có miễn ship thì phí vận chuyển = 0
		/// </summary>
		public double PhiVanChuyen { get; set; }

		/// <summary>
		/// lý do hủy đơn
		/// </summary>
		public string LyDoKhachHuy { get; set; }

		/// <summary>
		/// hóa đơn tại quầy hoặc online
		/// </summary>
		[Required(ErrorMessage = "Không được để trống")]
		public int LoaiHoaDon { get; set; }

		/// <summary>
		/// tiền mặt hoặc chuyển khoản
		/// </summary>
		[Required(ErrorMessage = "Không được để trống")]
		public string HinhThucThanhToan { get; set; }

		/// <summary>
		/// khóa ngoại
		/// </summary>
		public Guid IDCustomer { get; set; }

		public Guid IDStaff { get; set; }

		public Guid? IDVoucher { get; set; }
	}
}
