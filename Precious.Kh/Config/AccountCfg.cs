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
	public class AccountCfg : IEntityTypeConfiguration<Account>
	{
		public void Configure(EntityTypeBuilder<Account> builder)
		{
			builder.HasKey(p => p.IDUser);
			builder.HasOne(p => p.Customer).WithOne(p => p.Account).HasForeignKey<Account>(p => p.IDCustomer);
			builder.HasOne(p => p.Staff).WithOne(p => p.Account).HasForeignKey<Account>(p => p.IDStaff);
		}
	}
}
