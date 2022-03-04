using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionDetail> CollectionDetails { get; set; }

        //public IQueryable<Collection> SearchCustomers(string contactName)
        //{
        //    //SqlParameter pContactName = new SqlParameter("@ContactName", contactName);
        //    return this.Collections.FromSql("EXECUTE Customers_SearchCustomers @ContactName", pContactName);
        //}

        [DbFunction("fn_GetDriverBalance", "dbo")]
        public decimal fn_GetDriverBalance(int DriverId) => throw new NotSupportedException();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDbFunction(() => fn_GetDriverBalance(default(int)));


            modelBuilder.Entity<Office>()
            .HasKey(e => new { e.Id });

            modelBuilder.Entity<Office>()
                        .HasMany(e => e.DriverInformations)
                        .WithOne(e => e.Office)
                        .OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion

            modelBuilder.Entity<Office>()
                        .HasMany(e => e.Collections)
                        .WithOne(e => e.Office)
                        .OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion


            modelBuilder.Entity<Branch>()
            .HasKey(e => new { e.Id });

            modelBuilder.Entity<Branch>()
                        .HasMany(e => e.DriverInformations)
                        .WithOne(e => e.Branch)
                        .OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion


            modelBuilder.Entity<Session>()
            .HasKey(e => new { e.Id });

            modelBuilder.Entity<Session>()
                        .HasMany(e => e.DriverInformations)
                        .WithOne(e => e.Session)
                        .OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion

            modelBuilder.Entity<Collection>()
            .HasKey(e => new { e.Id });

            modelBuilder.Entity<Collection>()
                        .HasMany(e => e.CollectionDetails)
                        .WithOne(e => e.Collection)
                        .OnDelete(DeleteBehavior.Cascade); // <= This entity has cascade behaviour on deletion

            modelBuilder.Entity<PaymentType>()
            .HasKey(e => new { e.Id });

            modelBuilder.Entity<PaymentType>()
                        .HasMany(e => e.CollectionDetails)
                        .WithOne(e => e.PaymentType)
                        .OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion

            modelBuilder.Entity<CollectionDefinition>()
            .HasKey(e => new { e.Id });

            modelBuilder.Entity<CollectionDefinition>()
                        .HasMany(e => e.CollectionDetails)
                        .WithOne(e => e.CollectionDefinition)
                        .OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion

            modelBuilder.Entity<DriverInformation>()
            .HasKey(e => new { e.Id });

            modelBuilder.Entity<DriverInformation>()
                        .HasMany(e => e.Collections)
                        .WithOne(e => e.DriverInformation)
                        .OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion
        }

    }
}
