using Precious.core.IService;
using Precious.core.Models;
using Precious.Kh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.core.Service
{
	public class BillService : IBillService
	{
		AppDbContext _dbContext;
        public BillService(AppDbContext dbContext)
        {
			_dbContext = dbContext;
        }
        public async Task<(bool k, string msg)> CreateBillOffline(BillViewModel bill, List<BillDetailViewModel> detail)
		{
			try
			{
				if(bill == null || detail == null || !detail.Any())
				{
					return (false, "Thông tin không hợp lệ");
				}
				var genCode = GenerateSerialCode();
				bill.BillCode = genCode;

				var item = new Bill()
				{
					IDBill = Guid.NewGuid(),
					BillCode = genCode,
					Total = 0,
					NgayTao = DateTime.Now,
					NgayGiaoHang = DateTime.Now,
					NgayNhanHang = DateTime.Now,
					Status = 9,
					TenNguoiNhan = bill.TenNguoiNhan,
					EmailNguoiNhan = bill.EmailNguoiNhan,
					SDTNguoiNhan = bill.SDTNguoiNhan,
					DiaChiNguoiNhan = bill.DiaChiNguoiNhan,
					KhachThanhToan = bill.KhachThanhToan,
					GiamGia = bill.GiamGia,
					PhiVanChuyen = bill.PhiVanChuyen,
					LyDoKhachHuy = bill.LyDoKhachHuy,
					LoaiHoaDon = bill.LoaiHoaDon,
					HinhThucThanhToan = bill.HinhThucThanhToan,
					IDCustomer = bill.IDCustomer,
					IDStaff = bill.IDStaff,
					BillDetails = new List<BillDetail>()
				};

                foreach (var billDetail in detail)
                {
					item.BillDetails.Add(new BillDetail
					{
						IDBillDetail = Guid.NewGuid(),
						Quantity = billDetail.Quantity,
						Price = billDetail.Price,
						Status = billDetail.Status,
						IDBill = billDetail.IDBill,
						IDProductDetail = billDetail.IDProductDetail,
					});
                }
				await _dbContext.Bill.AddAsync(item);
				await _dbContext.SaveChangesAsync();
				return (true, "Tạo hóa đơn thành công");

            }
			catch (Exception ex)
			{
				return(false, ex.Message);
			}
		}

		private string GenerateSerialCode()
		{
			return Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper();
		}
	}
}
