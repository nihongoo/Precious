using Precious.core.IService;
using Precious.core.Models;
using Precious.Kh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Precious.core.Service
{
	public class StaffService : IStaffService
	{
		AppDbContext _dbContext;

        public StaffService()
        {
			_dbContext = new AppDbContext();
        }

		/// <summary>
		/// Create New Staff
		/// </summary>
		/// <param name="staff"></param>
		/// <returns></returns>
        public async Task<(bool k, string msg)> AddStaff(StaffViewModel staff)
		{
			try
			{
				if (_dbContext.Staff.Any(k => k.StaffCode == staff.StaffCode)) return (false, "Mã nhân viên đã tồn tại.");
				if (_dbContext.Staff.Any(k => k.Email == staff.Email)) return (false, "Email đã tồn tại.");
				if (_dbContext.Staff.Any(k => k.PhoneNumber == staff.PhoneNumber)) return (false, "Số điện thoại đã tồn tại");

				var stf = new Staff()
				{
					IdStaff = Guid.NewGuid(),
					StaffCode = "ST-" + staff.StaffCode,
					StaffName = staff.StaffName,
					Email = staff.Email,
					PhoneNumber = staff.PhoneNumber,
					Address = staff.Address,
					DateJoin = DateTime.Now,
					Status = 1
				};
				stf.IDUser = stf.IdStaff;
				_dbContext.Staff.Add(stf);

				var acc = new Account()
				{
					IDUser = stf.IdStaff,
					UserName = staff.UserName,
					Password = staff.Password,
					Role = "Staff",
					IDStaff = stf.IdStaff
				};
				_dbContext.Account.Add(acc);
				await _dbContext.SaveChangesAsync();
				return (true, "Tạo tài khoản thành công.");
			}
			catch (Exception ex)
			{
				return (false, ex.Message);
			}
		}
	}
}
