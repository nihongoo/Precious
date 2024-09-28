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
	public class CartCfg : IEntityTypeConfiguration<Cart>
	{
		public void Configure(EntityTypeBuilder<Cart> builder)
		{
			builder.HasKey(p => p.IDCart);
			builder.HasOne(p => p.Customer).WithOne(p => p.Cart).HasForeignKey<Cart>(p => p.IDCustomer);
		}
	}
}
