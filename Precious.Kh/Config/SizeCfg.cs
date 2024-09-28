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
	public class SizeCfg : IEntityTypeConfiguration<Size>
	{
		public void Configure(EntityTypeBuilder<Size> builder)
		{
			builder.HasKey(p => p.IDSize);
		}
	}
}
