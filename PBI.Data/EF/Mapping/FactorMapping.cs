using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PBI.Model.Accounting;

namespace PBI.Data.EF.Mapping
{
    public class FactorMapping : IEntityTypeConfiguration<Factor>
    {
        public void Configure(EntityTypeBuilder<Factor> builder)
        {
            builder.HasKey(r => r.ID);
            builder.ToTable("Factor");
        }
    }
}