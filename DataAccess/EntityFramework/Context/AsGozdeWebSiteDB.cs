using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework.Context
{
    public class AsGozdeWebSiteDB : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=AHMET\SQL2017;Database=AsGozdeWebSiteDB;Trusted_Connection=true", b => b.MigrationsAssembly("DataAccess"));
        }
        public DbSet<Office> Offices { get; set; }
    }
}
