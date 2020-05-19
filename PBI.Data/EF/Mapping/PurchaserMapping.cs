using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PBI.Model.Accounting;
using PBI.Model.Secretariat;

namespace PBI.Data.EF.Mapping
{
    public class PurchaserMapping : IEntityTypeConfiguration<Purchaser>
    {
        public void Configure(EntityTypeBuilder<Purchaser> builder)
        {
            builder.HasKey(r => r.ID);
            builder.ToTable("Purchaser");
            builder.HasOne(r => r.Factor).WithMany(r => r.Purchasers).HasForeignKey(r => r.FactorId).IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}