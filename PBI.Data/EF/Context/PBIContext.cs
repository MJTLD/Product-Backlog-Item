using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PBI.Data.EF.Mapping;
using PBI.Model.Base;
using PBI.Model.User;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("dbo");
            builder.ApplyConfiguration(new SampleMapping());
            base.OnModelCreating(builder);
        }

    }
}
