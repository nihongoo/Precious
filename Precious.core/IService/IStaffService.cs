using Precious.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.core.IService
{
	public interface IStaffService
	{
		Task<(bool k, string msg)> AddStaff(StaffViewModel staff);
	}
}
