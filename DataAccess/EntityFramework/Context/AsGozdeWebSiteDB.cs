using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Dtos;
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

        public DbSet<User> Users { get; set; }
        public DbSet<RoleType> RoleTypes { get; set; }
        public DbSet<RoleFormDefinition> RoleFormDefinitions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<sp_GetRole> Sp_GetRoles { get; set; }

        public DbSet<Office> Offices { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Branch> Branches { get; set; }        
        public DbSet<DriverInformation> DriverInformations { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<CollectionDefinition> CollectionDefinitions { get; set; }
        public DbSet<CollectionDefinitionType> CollectionDefinitionTypes { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionDetail> CollectionDetails { get; set; }
        public DbSet<DriverPaymentPlan> DriverPaymentPlans { get; set; }
        public DbSet<CollectionDefinitionAmount> CollectionDefinitionAmounts { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseDefinition> ExpenseDefinitions { get; set; }
        public DbSet<FixtureDefinition> FixtureDefinitions { get; set; }
        public DbSet<PersonnelDefinition> PersonnelDefinitions { get; set; }
        public DbSet<ReportLayout> ReportLayouts { get; set; }
        public virtual DbSet<sp_GetListOfDueCoursePayment> Sp_GetListOfDueCoursePayments { get; set; }
        public virtual DbSet<sp_GetPayment> Sp_GetPayments { get; set; }
        public virtual DbSet<sp_GetSequentialPayment> Sp_GetSequentialPayments { get; set; }
        public virtual DbSet<sp_GetListOfDriverInformationByOfficeId> Sp_GetListOfDriverInformationByOfficeIds { get; set; }
        public virtual DbSet<sp_GetListOfCollectionByOfficeId> Sp_GetListOfCollectionByOfficeIds { get; set; }
        public virtual DbSet<sp_GetListOfExpenseByOfficeId> Sp_GetListOfExpenseByOfficeIds { get; set; }
        public virtual DbSet<sp_rCashReport1> Sp_rCashReport1s { get; set; }
        public virtual DbSet<sp_rCashReport1DetailCollection> Sp_rCashReport1DetailCollections { get; set; }
        public virtual DbSet<sp_rCashReport1DetailExpense> Sp_rCashReport1DetailExpenses { get; set; }

        [DbFunction("fn_GetDriverBalance", "dbo")]
        public decimal fn_GetDriverBalance(int DriverId) => throw new NotSupportedException();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDbFunction(() => fn_GetDriverBalance(default(int)));

            modelBuilder.Entity<sp_GetRole>().HasNoKey();
            modelBuilder.Entity<sp_GetListOfDueCoursePayment>().HasNoKey();
            modelBuilder.Entity<sp_GetPayment>().HasNoKey();
            modelBuilder.Entity<sp_GetSequentialPayment>().HasNoKey();
            modelBuilder.Entity<sp_GetListOfDriverInformationByOfficeId>().HasNoKey();
            modelBuilder.Entity<sp_GetListOfCollectionByOfficeId>().HasNoKey();
            modelBuilder.Entity<sp_GetListOfExpenseByOfficeId>().HasNoKey();
            modelBuilder.Entity<sp_rCashReport1>().HasNoKey();
            modelBuilder.Entity<sp_rCashReport1DetailCollection>().HasNoKey();
            modelBuilder.Entity<sp_rCashReport1DetailExpense>().HasNoKey();


            ///User
            modelBuilder.Entity<User>().HasKey(e => e.UserId);
            modelBuilder.Entity<User>().Property(e => e.UserName).IsRequired().HasMaxLength(30).UseCollation("SQL_Latin1_General_CP1_CS_AS"); // Kullanıcı Kodu büyük küçük harf duyarlılığı için yapıldı.
            modelBuilder.Entity<User>().Property(e => e.PasswordHash).HasMaxLength(500);
            modelBuilder.Entity<User>().Property(e => e.FirstName).IsRequired().HasMaxLength(70);
            modelBuilder.Entity<User>().Property(e => e.LastName).HasMaxLength(100);
            modelBuilder.Entity<User>().Property(e => e.Title).HasMaxLength(150);



            ///RoleType
            modelBuilder.Entity<RoleType>().HasKey(e => e.Id);
            modelBuilder.Entity<RoleType>().Property(e => e.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<RoleType>().Property(e => e.Description).HasMaxLength(150);
            modelBuilder.Entity<RoleType>().HasMany(e => e.Users).WithOne(e => e.RoleType).OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion
            modelBuilder.Entity<RoleType>().HasMany(e => e.Roles).WithOne(e => e.RoleType).OnDelete(DeleteBehavior.Restrict); // <= This entity has cascade behaviour on deletion




            ///RoleDefinition
            modelBuilder.Entity<RoleFormDefinition>().HasKey(e => e.Id);
            modelBuilder.Entity<RoleFormDefinition>().Property(e => e.FormName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<RoleFormDefinition>().Property(e => e.FormSubName).HasMaxLength(100);
            modelBuilder.Entity<RoleFormDefinition>().Property(e => e.Description).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<RoleFormDefinition>().Property(e => e.SpecialRole1Description).HasMaxLength(150);
            modelBuilder.Entity<RoleFormDefinition>().Property(e => e.SpecialRole2Description).HasMaxLength(150);
            modelBuilder.Entity<RoleFormDefinition>().Property(e => e.SpecialRole3Description).HasMaxLength(150);
            modelBuilder.Entity<RoleFormDefinition>().Property(e => e.SpecialRole4Description).HasMaxLength(150);
            modelBuilder.Entity<RoleFormDefinition>().Property(e => e.SpecialRole5Description).HasMaxLength(150);
            modelBuilder.Entity<RoleFormDefinition>().HasMany(e => e.Roles).WithOne(e => e.RoleFormDefinition).OnDelete(DeleteBehavior.Restrict); // <= This entity has cascade behaviour on deletion



            ///Role
            modelBuilder.Entity<Role>().HasKey(e => e.Id);




            ///Office
            modelBuilder.Entity<Office>().HasKey(e => e.Id);
            modelBuilder.Entity<Office>().Property(e => e.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Office>().Property(e => e.Description).HasMaxLength(150);
            modelBuilder.Entity<Office>().Property(e => e.WebAddress).HasMaxLength(50);
            modelBuilder.Entity<Office>().Property(e => e.Email).HasMaxLength(50);
            modelBuilder.Entity<Office>().Property(e => e.Phone1).HasMaxLength(15);
            modelBuilder.Entity<Office>().Property(e => e.Phone2).HasMaxLength(15);
            modelBuilder.Entity<Office>().Property(e => e.Fax).HasMaxLength(15);
            modelBuilder.Entity<Office>().Property(e => e.City).HasMaxLength(50);
            modelBuilder.Entity<Office>().Property(e => e.County).HasMaxLength(50);
            modelBuilder.Entity<Office>().Property(e => e.Address1).HasMaxLength(100);
            modelBuilder.Entity<Office>().Property(e => e.Address2).HasMaxLength(100);
            modelBuilder.Entity<Office>().Property(e => e.TradeRegisterNumber).HasMaxLength(20);
            modelBuilder.Entity<Office>().Property(e => e.TaxOfficeName).HasMaxLength(50);
            modelBuilder.Entity<Office>().Property(e => e.TaxOfficeNo).HasMaxLength(20);
            modelBuilder.Entity<Office>().HasMany(e => e.DriverInformations).WithOne(e => e.Office).OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion
            modelBuilder.Entity<Office>().HasMany(e => e.Collections).WithOne(e => e.Office).OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion
            modelBuilder.Entity<Office>().HasMany(e => e.Expenses).WithOne(e => e.Office).OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion
            modelBuilder.Entity<Office>().HasMany(e => e.PersonnelDefinitions).WithOne(e => e.Office).OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion



            //Branch
            modelBuilder.Entity<Branch>().HasKey(e => e.Id);
            modelBuilder.Entity<Branch>().Property(e => e.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Branch>().Property(e => e.Description).HasMaxLength(150);
            modelBuilder.Entity<Branch>().HasMany(e => e.DriverInformations).WithOne(e => e.Branch).OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion



            ///Session
            modelBuilder.Entity<Session>().HasKey(e => e.Id);
            modelBuilder.Entity<Session>().Property(e => e.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Session>().Property(e => e.Description).HasMaxLength(150);
            modelBuilder.Entity<Session>().HasMany(e => e.DriverInformations).WithOne(e => e.Session).OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion



            ///Collection
            modelBuilder.Entity<Collection>().HasKey(e => e.Id);
            modelBuilder.Entity<Collection>().Property(e => e.CollectionDate).IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<Collection>().Property(e => e.DocumentNo).IsRequired().HasMaxLength(16);
            modelBuilder.Entity<Collection>().Property(e => e.AddedUserName).HasMaxLength(30);
            modelBuilder.Entity<Collection>().Property(e => e.AddedDateTime).HasColumnType("datetime");
            modelBuilder.Entity<Collection>().Property(e => e.UpdatedUserName).HasMaxLength(30);
            modelBuilder.Entity<Collection>().Property(e => e.UpdatedDateTime).HasColumnType("datetime");
            modelBuilder.Entity<Collection>().HasMany(e => e.CollectionDetails).WithOne(e => e.Collection).OnDelete(DeleteBehavior.Cascade); // <= This entity has cascade behaviour on deletion



            ///PaymentType
            modelBuilder.Entity<PaymentType>().HasKey(e => e.Id);
            modelBuilder.Entity<PaymentType>().Property(e => e.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<PaymentType>().Property(e => e.Description).HasMaxLength(150);
            modelBuilder.Entity<PaymentType>().HasMany(e => e.CollectionDetails).WithOne(e => e.PaymentType).OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion
            modelBuilder.Entity<PaymentType>().HasMany(e => e.Expenses).WithOne(e => e.PaymentType).OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion



            ///CollectionDefinition
            modelBuilder.Entity<CollectionDefinition>().HasKey(e => e.Id);
            modelBuilder.Entity<CollectionDefinition>().Property(e => e.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<CollectionDefinition>().Property(e => e.Description).HasMaxLength(150);
            modelBuilder.Entity<CollectionDefinition>().HasMany(e => e.CollectionDetails).WithOne(e => e.CollectionDefinition).OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion
            modelBuilder.Entity<CollectionDefinition>().HasMany(e => e.CollectionDefinitionAmounts).WithOne(e => e.CollectionDefinition).OnDelete(DeleteBehavior.Cascade);  // <= This entity has cascade behaviour on deletion



            ///CollectionDefinitionType
            modelBuilder.Entity<CollectionDefinitionType>().HasKey(e => e.Id);
            modelBuilder.Entity<CollectionDefinitionType>().Property(e => e.Name).IsRequired().HasMaxLength(150);
            modelBuilder.Entity<CollectionDefinitionType>().Property(e => e.Description).HasMaxLength(150);
            modelBuilder.Entity<CollectionDefinitionType>().HasMany(e => e.CollectionDefinitions).WithOne(e => e.CollectionDefinitionType).OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion



            ///CollectionDefinitionAmount
            modelBuilder.Entity<CollectionDefinitionAmount>().HasKey(e => e.Id);
            modelBuilder.Entity<CollectionDefinitionAmount>().Property(e => e.Year).IsRequired().HasMaxLength(4);
            modelBuilder.Entity<CollectionDefinitionAmount>().Property(e => e.AddedUserName).HasMaxLength(30);
            modelBuilder.Entity<CollectionDefinitionAmount>().Property(e => e.AddedDateTime).HasColumnType("datetime");
            modelBuilder.Entity<CollectionDefinitionAmount>().Property(e => e.UpdatedUserName).HasMaxLength(30);
            modelBuilder.Entity<CollectionDefinitionAmount>().Property(e => e.UpdatedDateTime).HasColumnType("datetime");



            ////CollectionDetail
            modelBuilder.Entity<CollectionDetail>().HasKey(e => e.Id);
            modelBuilder.Entity<CollectionDetail>().Property(e => e.AddedUserName).HasMaxLength(30);
            modelBuilder.Entity<CollectionDetail>().Property(e => e.AddedDateTime).HasColumnType("datetime");
            modelBuilder.Entity<CollectionDetail>().Property(e => e.UpdatedUserName).HasMaxLength(30);
            modelBuilder.Entity<CollectionDetail>().Property(e => e.UpdatedDateTime).HasColumnType("datetime");
            modelBuilder.Entity<CollectionDetail>().Property(e => e.Note).HasMaxLength(200);



            ///DriverInformation
            modelBuilder.Entity<DriverInformation>().HasKey(e => e.Id);
            modelBuilder.Entity<DriverInformation>().Property(e => e.Name).IsRequired().HasMaxLength(70);
            modelBuilder.Entity<DriverInformation>().Property(e => e.Surname).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<DriverInformation>().Property(e => e.IdentityNo).IsRequired().HasMaxLength(11);
            modelBuilder.Entity<DriverInformation>().Property(e => e.Email).HasMaxLength(50);
            modelBuilder.Entity<DriverInformation>().Property(e => e.Phone1).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<DriverInformation>().Property(e => e.Phone2).IsRequired().HasMaxLength(15);
            modelBuilder.Entity<DriverInformation>().Property(e => e.City).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<DriverInformation>().Property(e => e.County).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<DriverInformation>().Property(e => e.Address1).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<DriverInformation>().Property(e => e.Address2).HasMaxLength(100);
            modelBuilder.Entity<DriverInformation>().Property(e => e.RecordDate).IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<DriverInformation>().Property(e => e.Note).HasMaxLength(200);
            modelBuilder.Entity<DriverInformation>().Property(e => e.CertificateDeliveredDate).HasColumnType("datetime");
            modelBuilder.Entity<DriverInformation>().HasMany(e => e.Collections).WithOne(e => e.DriverInformation).OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion
            modelBuilder.Entity<DriverInformation>().HasMany(e => e.DriverPaymentPlans).WithOne(e => e.DriverInformation).OnDelete(DeleteBehavior.Cascade);  // <= This entity has cascade behaviour on deletion



            ////DriverPaymentPlan
            modelBuilder.Entity<DriverPaymentPlan>().HasKey(e => e.Id);
            modelBuilder.Entity<DriverPaymentPlan>().Property(e => e.DriverInformationId).IsRequired();
            modelBuilder.Entity<DriverPaymentPlan>().Property(e => e.PaymentDate).IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<DriverPaymentPlan>().Property(e => e.AddedUserName).HasMaxLength(30);
            modelBuilder.Entity<DriverPaymentPlan>().Property(e => e.AddedDateTime).HasColumnType("datetime");
            modelBuilder.Entity<DriverPaymentPlan>().Property(e => e.UpdatedUserName).HasMaxLength(30);
            modelBuilder.Entity<DriverPaymentPlan>().Property(e => e.UpdatedDateTime).HasColumnType("datetime");



            ////Expense
            modelBuilder.Entity<Expense>().HasKey(e => e.Id);
            modelBuilder.Entity<Expense>().Property(e => e.ExpenseDate).IsRequired().HasColumnType("datetime");
            modelBuilder.Entity<Expense>().Property(e => e.DocumentNo).IsRequired().HasMaxLength(16);
            modelBuilder.Entity<Expense>().Property(e => e.Description).HasMaxLength(150);
            modelBuilder.Entity<Expense>().Property(e => e.AddedUserName).HasMaxLength(30);
            modelBuilder.Entity<Expense>().Property(e => e.AddedDateTime).HasColumnType("datetime");
            modelBuilder.Entity<Expense>().Property(e => e.UpdatedUserName).HasMaxLength(30);
            modelBuilder.Entity<Expense>().Property(e => e.UpdatedDateTime).HasColumnType("datetime");



            ////ExpenseDefinition
            modelBuilder.Entity<ExpenseDefinition>().HasKey(e => e.Id);
            modelBuilder.Entity<ExpenseDefinition>().Property(e => e.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<ExpenseDefinition>().Property(e => e.Description).HasMaxLength(150);
            modelBuilder.Entity<ExpenseDefinition>().HasMany(e => e.Expenses).WithOne(e => e.ExpenseDefinition).OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion



            ////FixtureDefinition
            modelBuilder.Entity<FixtureDefinition>().HasKey(e => e.Id);
            modelBuilder.Entity<FixtureDefinition>().Property(e => e.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<FixtureDefinition>().Property(e => e.Description).HasMaxLength(150);
            modelBuilder.Entity<FixtureDefinition>().Property(e => e.Note).HasMaxLength(200);
            modelBuilder.Entity<FixtureDefinition>().HasMany(e => e.Expenses).WithOne(e => e.FixtureDefinition).OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion



            ///PersonnelDefinition
            modelBuilder.Entity<PersonnelDefinition>().HasKey(e => e.Id);
            modelBuilder.Entity<PersonnelDefinition>().Property(e => e.Name).IsRequired().HasMaxLength(70);
            modelBuilder.Entity<PersonnelDefinition>().Property(e => e.Surname).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<PersonnelDefinition>().Property(e => e.IdentityNo).HasMaxLength(11);
            modelBuilder.Entity<PersonnelDefinition>().Property(e => e.Job).HasMaxLength(100);
            modelBuilder.Entity<PersonnelDefinition>().Property(e => e.Position).HasMaxLength(100);
            modelBuilder.Entity<PersonnelDefinition>().Property(e => e.Email).HasMaxLength(50);
            modelBuilder.Entity<PersonnelDefinition>().Property(e => e.Phone1).HasMaxLength(15);
            modelBuilder.Entity<PersonnelDefinition>().Property(e => e.Phone2).HasMaxLength(15);
            modelBuilder.Entity<PersonnelDefinition>().Property(e => e.City).HasMaxLength(50);
            modelBuilder.Entity<PersonnelDefinition>().Property(e => e.County).HasMaxLength(50);
            modelBuilder.Entity<PersonnelDefinition>().Property(e => e.Address1).HasMaxLength(100);
            modelBuilder.Entity<PersonnelDefinition>().Property(e => e.Address2).HasMaxLength(100);
            modelBuilder.Entity<PersonnelDefinition>().Property(e => e.StartDate).HasColumnType("datetime");
            modelBuilder.Entity<PersonnelDefinition>().Property(e => e.EndDate).HasColumnType("datetime");
            modelBuilder.Entity<PersonnelDefinition>().Property(e => e.Note).HasMaxLength(200);
            modelBuilder.Entity<PersonnelDefinition>().HasMany(e => e.Expenses).WithOne(e => e.PersonnelDefinition).OnDelete(DeleteBehavior.Restrict); // <= This entity has restricted behaviour on deletion




            ////ReportLayout
            modelBuilder.Entity<ReportLayout>().HasKey(e => e.ReportId);
            modelBuilder.Entity<ReportLayout>().Property(e => e.DisplayName).IsRequired().HasMaxLength(250);

        }

    }
}
