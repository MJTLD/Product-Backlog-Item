using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PBI.Model.Accounting;
using PBI.Model.Secretariat;

namespace PBI.Data.EF.Mapping
{
    public class VendorMapping : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.HasKey(r => r.ID);
            builder.ToTable("Vendor");
            builder.HasOne(r => r.Factor).WithMany(r => r.Vendors).HasForeignKey(r => r.FactorId).IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}