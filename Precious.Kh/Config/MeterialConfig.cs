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
	public class MeterialConfig : IEntityTypeConfiguration<Meterial>
	{
		public void Configure(EntityTypeBuilder<Meterial> builder)
		{
			builder.HasKey(k => k.IDMeterial);
		}
	}
}
