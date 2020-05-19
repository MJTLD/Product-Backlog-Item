using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PBI.Model.ProductSpecifications;

namespace PBI.Data.EF.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(r => r.ID);
            builder.ToTable("Product");
            builder.HasOne(r => r.Factor).WithMany(r => r.Products).HasForeignKey(r => r.FactorId).IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}