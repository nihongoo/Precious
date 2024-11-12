using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.core.Models
{
	public class BillDTO
	{
		public BillViewModel Bill { get; set; }
		public List<BillDetailViewModel> BillDetail { get; set; }
	}
}
