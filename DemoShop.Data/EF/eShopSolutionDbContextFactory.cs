using eShopSolution.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace eShopSolution.Data.EF
{
    class eShopSolutionDbContextFactory :  IDesignTimeDbContextFactory<eShopSolutionDbContext>
    {
        public eShopSolutionDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettingss.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DemoShopDb");

            var optionsBuilder = new DbContextOptionsBuilder<eShopSolutionDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new eShopSolutionDbContext(optionsBuilder.Options);
        }

    }
}
