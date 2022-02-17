using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework.Context
{
    public class AsGozdeWebSiteDB : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("AsGozdeDatabase"), b => b.MigrationsAssembly("DataAccess"));

        }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DriverInformation> DriverInformations { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<CollectionDefinition> CollectionDefinitions { get; set; }
    }
}
