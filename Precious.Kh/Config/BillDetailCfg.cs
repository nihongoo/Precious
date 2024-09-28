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
	public class BillDetailCfg : IEntityTypeConfiguration<BillDetail>
	{
		public void Configure(EntityTypeBuilder<BillDetail> builder)
		{
			builder.HasKey(p => p.IDBillDetail);
			builder.HasOne(p => p.Bill).WithMany(p => p.BillDetails).HasForeignKey(p => p.IDBill);
			builder.HasOne(p => p.ProductDetail).WithMany(p => p.BillDetails).HasForeignKey(p => p.IDProductDetail);
		}
	}
}
