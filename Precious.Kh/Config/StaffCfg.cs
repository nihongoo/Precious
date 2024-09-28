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
	public class StaffCfg : IEntityTypeConfiguration<Staff>
	{
		public void Configure(EntityTypeBuilder<Staff> builder)
		{
			builder.HasKey(p => p.IdStaff);
			//builder.HasOne(p=>p.Account).WithOne(p=>p.Staff).HasForeignKey<Staff>(p=>p.IDUser);
		}
	}
}
