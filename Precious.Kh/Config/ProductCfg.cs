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
	public class ProductCfg : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasKey(p => p.IDProduct);
			builder.HasOne(p => p.Brand).WithMany(p => p.Products).HasForeignKey(p => p.IDBrand);
			builder.HasOne(p => p.Meterial).WithMany(p => p.Products).HasForeignKey(p => p.IDMeterial);
			builder.HasOne(p => p.Category).WithMany(p => p.Products).HasForeignKey(p => p.IDCategory);
			builder.HasOne(p => p.TagetCustomer).WithMany(p => p.Products).HasForeignKey(p => p.IDTagetCustomer);
		}
	}
}
