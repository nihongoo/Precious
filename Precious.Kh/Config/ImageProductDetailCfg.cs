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
	public class ImageProductDetailCfg : IEntityTypeConfiguration<ImageProductDetail>
	{
		public void Configure(EntityTypeBuilder<ImageProductDetail> builder)
		{
			builder.HasKey(p => p.IDImageProductDetail);
			builder.HasOne(p => p.ProductDetail).WithMany(p => p.ImageProductDetail).HasForeignKey(p => p.IDProductDetail);
		}
	}
}
