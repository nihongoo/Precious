using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Precious.Kh.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Precious.Kh.Config
{
	public class ProductDetailCfg : IEntityTypeConfiguration<ProductDetail>
	{
		public void Configure(EntityTypeBuilder<ProductDetail> builder)
		{
			builder.HasKey(p => p.IDProductDetail);
			builder.HasOne(p => p.Sale).WithMany(p => p.ProductDetails).HasForeignKey(p => p.IDSale);
			builder.HasOne(p => p.Color).WithMany(p => p.ProductDetails).HasForeignKey(p => p.IDColor);
			builder.HasOne(p => p.Product).WithMany(p => p.ProductDetail).HasForeignKey(p => p.IDProduct);
			builder.HasOne(p => p.Size).WithMany(p => p.ProductDetails).HasForeignKey(p => p.IDSize);
		}
	}
}
