using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Precious.core.IService;
using Precious.Kh.Model;
using System.Security.Cryptography.X509Certificates;

namespace Precious.core.Service
{
	public class AllService<T> : IAllService<T> where T : class
	{
		private readonly AppDbContext _dbContext;
		private readonly DbSet<T> _dbSet;
		public AllService()
		{
			_dbContext = new AppDbContext();
		}

		public AllService(AppDbContext dbContext)
		{
			this._dbContext = dbContext;
			this._dbSet = _dbContext.Set<T>();
		}

		public async Task<List<T>> GetAll()
		{
			return await _dbSet.ToListAsync();
		}

		public async Task<T> GetAsync(dynamic ID)
		{
			return await _dbSet.FindAsync(ID);
		}

		public async Task<(bool k, string msg)> Add(T obj)
		{
			try
			{
				await _dbSet.AddAsync(obj);
				await _dbContext.SaveChangesAsync();
				return (true, "Thêm thành công");
			}
			catch (Exception ex)
			{
				return (false, "Thêm thất bại, " + ex.Message);
			}
		}

		public async Task<(bool k, string msg)> Update(T obj)
		{
			try
			{
				//đảm bảo là obj đã tồn tại
				_dbSet.Attach(obj);

				//đánh dấu đối tượng đã đc thay đổi
				_dbContext.Entry(obj).State = EntityState.Modified;

				//lưu thay đổi
				await _dbContext.SaveChangesAsync();
				return (true, "Sửa thành công");
			}
			catch (Exception ex)
			{
				return (false, "Sửa thất bại, " + ex.Message);
			}
		}

		public async Task<(bool k, string msg)> Delete(dynamic ID)
		{
			try
			{
				var del = await _dbSet.FindAsync(ID);
				if(del == null)
				{
					return (false, "Không tìm thấy đối tượng.");
				}
				_dbSet.Remove(del);
				await _dbContext.SaveChangesAsync();
				return (true, "Xóa thành công");
			}
			catch (Exception ex)
			{
				return (false, "Xóa thất bại, " + ex.Message);
			}
		}

		public async Task<(bool k, string msg)> CheckUnique(string prod, object value)
		{
			try
			{
				var result = await _dbSet.AnyAsync(x => EF.Property<object>(x, prod).Equals(value));
				if (result) return (false, $"{prod} đã tồn tại");
				else return (true, "");
			}
			catch (Exception ex)
			{
				return (false,"Đã có lỗi: "+ ex.Message);
			}
		}
	}
}
