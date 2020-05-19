using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PBI.Data.EF.Mapping;
using PBI.Model.Accounting;
using PBI.Model.Base;
using PBI.Model.ProductSpecifications;
using PBI.Model.User;
using PBI.Model.Secretariat;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PBI.Data.EF.Context
{
    public class PBIContext : IdentityDbContext<ApplicationUser>
    {
        public PBIContext(DbContextOptions<PBIContext> options) : base(options)
        {

        }

        public DbSet<Sample> Sample { get; set; }
        public DbSet<Factor> Factor { get; set; }
        public DbSet<Purchaser> Purchaser { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Letter> Letter { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("dbo");
            builder.ApplyConfiguration(new SampleMapping());
            builder.ApplyConfiguration(new VendorMapping());
            builder.ApplyConfiguration(new PurchaserMapping());
            builder.ApplyConfiguration(new ProductMapping());
            builder.ApplyConfiguration(new LetterMapping());
            builder.ApplyConfiguration(new FactorMapping());
            base.OnModelCreating(builder);
        }

    }
}
