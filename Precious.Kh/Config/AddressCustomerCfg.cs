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
	public class AddressCustomerCfg : IEntityTypeConfiguration<AddressCustomer>
	{
		public void Configure(EntityTypeBuilder<AddressCustomer> builder)
		{
			builder.HasKey(p => p.IDAddress);
			builder.HasOne(p => p.Customer).WithMany(p => p.Address).HasForeignKey(p => p.IDCustomer);
		}
	}
}
