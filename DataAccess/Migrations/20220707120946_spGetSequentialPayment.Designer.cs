﻿// <auto-generated />
using System;
using DataAccess.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(AsGozdeWebSiteDB))]
    [Migration("20220707120946_spGetSequentialPayment")]
    partial class spGetSequentialPayment
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.Concrete.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .UseCollation("SQL_Latin1_General_CP1_CS_AS");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.Concrete.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Entities.Concrete.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("AddedUserName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("CollectionDate")
                        .HasColumnType("datetime");

                    b.Property<string>("DocumentNo")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("DriverInformationId")
                        .HasColumnType("int");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatedUserName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("DriverInformationId");

                    b.HasIndex("OfficeId");

                    b.ToTable("Collections");
                });

            modelBuilder.Entity("Entities.Concrete.CollectionDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CollectionDefinitionTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("IsSequence")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("PayBySelf")
                        .HasColumnType("bit");

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CollectionDefinitionTypeId");

                    b.ToTable("CollectionDefinitions");
                });

            modelBuilder.Entity("Entities.Concrete.CollectionDefinitionAmount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("AddedUserName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CollectionDefinitionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatedUserName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Year")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CollectionDefinitionId");

                    b.ToTable("CollectionDefinitionAmounts");
                });

            modelBuilder.Entity("Entities.Concrete.CollectionDefinitionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("IsPayBySelf")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSequence")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("CollectionDefinitionTypes");
                });

            modelBuilder.Entity("Entities.Concrete.CollectionDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDateTime")
                        .HasColumnType("datetime");

                    b.Property<int>("AddedUserId")
                        .HasColumnType("int");

                    b.Property<string>("AddedUserName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CollectionDefinitionId")
                        .HasColumnType("int");

                    b.Property<int>("CollectionId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatedUserName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CollectionDefinitionId");

                    b.HasIndex("CollectionId");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("CollectionDetails");
                });

            modelBuilder.Entity("Entities.Concrete.DriverInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Address2")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("CourseFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("IdentityNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Note")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<string>("Phone1")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Phone2")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("OfficeId");

                    b.HasIndex("SessionId");

                    b.ToTable("DriverInformations");
                });

            modelBuilder.Entity("Entities.Concrete.DriverPaymentPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("AddedUserName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DriverInformationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdatedUserName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("DriverInformationId");

                    b.ToTable("DriverPaymentPlans");
                });

            modelBuilder.Entity("Entities.Concrete.Office", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Address2")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("County")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Fax")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone1")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Phone2")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("TaxOfficeName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TaxOfficeNo")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TradeRegisterNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("WebAddress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Offices");
                });

            modelBuilder.Entity("Entities.Concrete.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("Entities.Concrete.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Entities.Dtos.sp_GetListOfDueCoursePayment", b =>
                {
                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("BranchName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CourseFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DebitinMonth")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DriverInformationId")
                        .HasColumnType("int");

                    b.Property<int>("DriverPaymentPlanId")
                        .HasColumnType("int");

                    b.Property<decimal>("LastDebit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OfficeId")
                        .HasColumnType("int");

                    b.Property<string>("OfficeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<string>("SessionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SessionYear")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalCourseCollectionAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalDebitByPaymentDate")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("Sp_GetListOfDueCoursePayments");
                });

            modelBuilder.Entity("Entities.Dtos.sp_GetPayment", b =>
                {
                    b.Property<int>("ClosingCollectionCount")
                        .HasColumnType("int");

                    b.Property<string>("CollectionDates")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CollectionDetailIds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CollectionIds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CollectionTypeNames")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Debit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DriverPaymentPlanDriverInformationId")
                        .HasColumnType("int");

                    b.Property<int>("DriverPaymentPlanId")
                        .HasColumnType("int");

                    b.Property<int>("DriverPaymentPlanSequence")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PaymentPlanAmount")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("Sp_GetPayments");
                });

            modelBuilder.Entity("Entities.Dtos.sp_GetSequentialPayment", b =>
                {
                    b.Property<DateTime>("CollectionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CollectionDefinitionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CollectionDefinitionId")
                        .HasColumnType("int");

                    b.Property<string>("CollectionDefinitionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CollectionDefinitionPayBySelf")
                        .HasColumnType("bit");

                    b.Property<int>("CollectionDefinitionSequence")
                        .HasColumnType("int");

                    b.Property<int>("CollectionDefinitionTypeId")
                        .HasColumnType("int");

                    b.Property<string>("CollectionDefinitionTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CollectionDetailAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CollectionDetailId")
                        .HasColumnType("int");

                    b.Property<int>("CollectionId")
                        .HasColumnType("int");

                    b.Property<string>("DocumentNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DriverInformationId")
                        .HasColumnType("int");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("int");

                    b.ToTable("Sp_GetSequentialPayments");
                });

            modelBuilder.Entity("Entities.Concrete.Collection", b =>
                {
                    b.HasOne("Entities.Concrete.DriverInformation", "DriverInformation")
                        .WithMany("Collections")
                        .HasForeignKey("DriverInformationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Office", "Office")
                        .WithMany("Collections")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DriverInformation");

                    b.Navigation("Office");
                });

            modelBuilder.Entity("Entities.Concrete.CollectionDefinition", b =>
                {
                    b.HasOne("Entities.Concrete.CollectionDefinitionType", "CollectionDefinitionType")
                        .WithMany("CollectionDefinitions")
                        .HasForeignKey("CollectionDefinitionTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CollectionDefinitionType");
                });

            modelBuilder.Entity("Entities.Concrete.CollectionDefinitionAmount", b =>
                {
                    b.HasOne("Entities.Concrete.CollectionDefinition", "CollectionDefinition")
                        .WithMany("CollectionDefinitionAmounts")
                        .HasForeignKey("CollectionDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CollectionDefinition");
                });

            modelBuilder.Entity("Entities.Concrete.CollectionDetail", b =>
                {
                    b.HasOne("Entities.Concrete.CollectionDefinition", "CollectionDefinition")
                        .WithMany("CollectionDetails")
                        .HasForeignKey("CollectionDefinitionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Collection", "Collection")
                        .WithMany("CollectionDetails")
                        .HasForeignKey("CollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.PaymentType", "PaymentType")
                        .WithMany("CollectionDetails")
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Collection");

                    b.Navigation("CollectionDefinition");

                    b.Navigation("PaymentType");
                });

            modelBuilder.Entity("Entities.Concrete.DriverInformation", b =>
                {
                    b.HasOne("Entities.Concrete.Branch", "Branch")
                        .WithMany("DriverInformations")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Office", "Office")
                        .WithMany("DriverInformations")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Session", "Session")
                        .WithMany("DriverInformations")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Office");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("Entities.Concrete.DriverPaymentPlan", b =>
                {
                    b.HasOne("Entities.Concrete.DriverInformation", "DriverInformation")
                        .WithMany("DriverPaymentPlans")
                        .HasForeignKey("DriverInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DriverInformation");
                });

            modelBuilder.Entity("Entities.Concrete.Branch", b =>
                {
                    b.Navigation("DriverInformations");
                });

            modelBuilder.Entity("Entities.Concrete.Collection", b =>
                {
                    b.Navigation("CollectionDetails");
                });

            modelBuilder.Entity("Entities.Concrete.CollectionDefinition", b =>
                {
                    b.Navigation("CollectionDefinitionAmounts");

                    b.Navigation("CollectionDetails");
                });

            modelBuilder.Entity("Entities.Concrete.CollectionDefinitionType", b =>
                {
                    b.Navigation("CollectionDefinitions");
                });

            modelBuilder.Entity("Entities.Concrete.DriverInformation", b =>
                {
                    b.Navigation("Collections");

                    b.Navigation("DriverPaymentPlans");
                });

            modelBuilder.Entity("Entities.Concrete.Office", b =>
                {
                    b.Navigation("Collections");

                    b.Navigation("DriverInformations");
                });

            modelBuilder.Entity("Entities.Concrete.PaymentType", b =>
                {
                    b.Navigation("CollectionDetails");
                });

            modelBuilder.Entity("Entities.Concrete.Session", b =>
                {
                    b.Navigation("DriverInformations");
                });
#pragma warning restore 612, 618
        }
    }
}
