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
	public class CartDetailCfg : IEntityTypeConfiguration<CartDetail>
	{
		public void Configure(EntityTypeBuilder<CartDetail> builder)
		{
			builder.HasKey(p => p.IDCartDetail);
			builder.HasOne(p => p.Cart).WithMany(p => p.CartDetails).HasForeignKey(p => p.IDCart);
			builder.HasOne(p => p.ProductDetail).WithMany(p => p.CartDetails).HasForeignKey(p => p.IDProductDetail);
		}
	}
}
