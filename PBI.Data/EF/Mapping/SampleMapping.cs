using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PBI.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace PBI.Data.EF.Mapping
{
    public class SampleMapping : IEntityTypeConfiguration<Sample>
    {
        public void Configure(EntityTypeBuilder<Sample> builder)
        {
            builder.HasKey(r => r.ID);
            builder.ToTable("Sample");
        }
    }
}
