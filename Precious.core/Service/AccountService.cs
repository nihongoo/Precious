using Microsoft.EntityFrameworkCore;
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
	public class AccountService : IAccountService
	{
		private readonly AppDbContext _dbContext;

		public AccountService()
		{
			_dbContext = new AppDbContext();
		}

		/// <summary>
		/// login
		/// </summary>
		/// <param name="UserName"></param>
		/// <param name="PassWord"></param>
		/// <returns></returns>
		public async Task<(bool k, string msg, object CrUser)> Login(string UserName, string PassWord)
		{
			if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(PassWord))
			{
				return (false, "Vui lòng nhập tài khoản và mật khẩu để đăng nhập.", null);
			}
			var data = await _dbContext.Account.FirstOrDefaultAsync(p => p.UserName == UserName && p.Password == PassWord);
			if (data == null) { return (false, "Đăng nhập thất bại.",null); }
			if (data.Role == "Customer")
			{
				var CrUser = await (from acc in _dbContext.Account
									join cus in _dbContext.Customer
									on acc.IDUser equals cus.IDUser
									where acc.IDUser == cus.IDUser
									select new CustomerViewModel()
									{
										IDCustomer = cus.IDCustomer,
										Name = cus.Name,
										GioiTinh = cus.GioiTinh,
										BirthDay = cus.BirthDay,
										PhoneNumber = cus.PhoneNumber,
										Email = cus.Email,
										Status = cus.Status,
										IDUser = acc.IDUser,
										UserName = acc.UserName,
										Password = acc.Password,
										Role = acc.Role
									}).FirstOrDefaultAsync();
				return (true, "Đăng nhập thành công.", CrUser);
			}
			else if(data.Role == "Staff")
			{
				var CrStaff = await (from acc in _dbContext.Account
									join stf in _dbContext.Staff
									on acc.IDUser equals stf.IDUser
									where acc.IDUser == stf.IDUser
									select new StaffViewModel()
									{
										IdStaff = stf.IdStaff,
										StaffCode = stf.StaffCode,
										StaffName = stf.StaffName,
										Email = stf.Email,
										PhoneNumber = stf.PhoneNumber,
										Address = stf.Address,
										DateJoin = stf.DateJoin,
										Status = stf.Status,
										IDUser = acc.IDUser,
										UserName = acc.UserName,
										Password = acc.Password,
										Role = acc.Role
									}).FirstOrDefaultAsync();
				return (true, "Đăng nhập thành công.", CrStaff);
			}
			return (true, "Đăng nhập thành công.", data);
		}

		/// <summary>
		/// Sign Up
		/// </summary>
		/// <param name="Customer"></param>
		/// <returns></returns>
		public async Task<(bool k, string msg)> SignUp(CustomerViewModel Customer)
		{
			try
			{
				if (_dbContext.Customer.Any(k => k.Email == Customer.Email)) return (false,"Email đã tồn tại.");
				if (_dbContext.Customer.Any(k => k.PhoneNumber == Customer.PhoneNumber)) return (false, "Số điện thoại đã tồn tại.");
				var cus = new Customer()
				{
					IDCustomer = Guid.NewGuid(),
					Name = Customer.Name,
					GioiTinh = Customer.GioiTinh,
					BirthDay = Customer.BirthDay,
					PhoneNumber = Customer.PhoneNumber,
					Email = Customer.Email,
					Status = 1,
				};
				cus.IDUser = cus.IDCustomer;
				_dbContext.Customer.Add(cus);

				var acc = new Account()
				{
					IDUser = cus.IDCustomer,
					UserName = Customer.UserName,
					Password = Customer.Password,
					Role = "Customer",
					IDCustomer = cus.IDCustomer,
				};
				_dbContext.Account.Add(acc);

				var Cart = new Cart()
				{
					IDCart = cus.IDCustomer,
					IDCustomer = cus.IDCustomer,
					Status = "Đang hoạt động",
					CreateTime = DateTime.Now,
					Total = 0
				};
				_dbContext.Cart.Add(Cart);
				await _dbContext.SaveChangesAsync();
				return (true, "Tạo tài khoản thành công");
			}
			catch (Exception ex)
			{
				return (false, ex.Message);
			}
		}
	}
}
