using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PBI.Data.EF.Context
{
    public class FactoryContext : IDesignTimeDbContextFactory<PBIContext>
    {
        public PBIContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<PBIContext>();
            builder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            return new PBIContext(builder.Options);
        }
    }
}
