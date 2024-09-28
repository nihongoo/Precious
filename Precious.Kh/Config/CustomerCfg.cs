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
	public class CustomerCfg : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> builder)
		{
			builder.HasKey(p => p.IDCustomer);
			//builder.HasOne(p => p.Account).WithOne(p => p.Customer).HasForeignKey<Customer>(p => p.IDUser);
		}
	}
}
