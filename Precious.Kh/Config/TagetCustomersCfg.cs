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
	public class TagetCustomersCfg : IEntityTypeConfiguration<TagetCustomers>
	{
		public void Configure(EntityTypeBuilder<TagetCustomers> builder)
		{
			builder.HasKey(p => p.IDTagetCustomer);
		}
	}
}
