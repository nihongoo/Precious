using Precious.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.core.IService
{
	public interface IBillService
	{
		Task<(bool k, string msg)> CreateBillOffline(BillViewModel bill, List<BillDetailViewModel> detail);
	}
}
