using Precious.core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.core.IService
{
	public interface IAccountService
	{
		Task<(bool k, string msg, object CrUser)> Login(string UserName, string PassWord);
		Task<(bool k, string msg)> SignUp(CustomerViewModel Customer);
	}
}
