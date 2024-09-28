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
	public class FavoriteProductsCfg : IEntityTypeConfiguration<FavoriteProducts>
	{
		public void Configure(EntityTypeBuilder<FavoriteProducts> builder)
		{
			builder.HasKey(p => new { p.IDProduct, p.IDCustomer });
			builder.HasOne(p => p.Product).WithOne(p => p.FavoriteProducts).HasForeignKey<FavoriteProducts>(p => p.IDProduct);
			builder.HasOne(p => p.Customer).WithMany(p => p.FavoriteProducts).HasForeignKey(p => p.IDCustomer);
		}
	}
}
