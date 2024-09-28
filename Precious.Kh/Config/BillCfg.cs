using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Precious.Kh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.Kh.Config
{
	public class BillCfg : IEntityTypeConfiguration<Bill>
	{
		public void Configure(EntityTypeBuilder<Bill> builder)
		{
			builder.HasKey(p => p.IDBill);
			builder.HasOne(p => p.Customer).WithMany(p => p.Bills).HasForeignKey(p => p.IDCustomer);
			builder.HasOne(p => p.Staff).WithMany(p => p.Bills).HasForeignKey(p => p.IDStaff);
			builder.HasOne(p => p.Voucher).WithMany(p => p.Bill).HasForeignKey(p => p.IDVoucher);
		}
	}
}
