﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewVehiclePreApproval.Infrastructure;

#nullable disable

namespace NewVehiclePreApproval.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NewVehiclePreApproval.Domain.Dealerships.Dealership", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique()
                        .HasFilter("[PhoneNumber] IS NOT NULL");

                    b.ToTable("dealerships", (string)null);
                });

            modelBuilder.Entity("NewVehiclePreApproval.Domain.Requests.Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("RejectionReason")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("requests", (string)null);
                });

            modelBuilder.Entity("NewVehiclePreApproval.Domain.Requests.Request", b =>
                {
                    b.OwnsOne("NewVehiclePreApproval.Domain.Requests.ClientInformation", "ClientInformation", b1 =>
                        {
                            b1.Property<Guid>("RequestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Dni")
                                .IsRequired()
                                .HasMaxLength(13)
                                .HasColumnType("nvarchar(13)");

                            b1.Property<string>("Email")
                                .HasMaxLength(150)
                                .HasColumnType("nvarchar(150)");

                            b1.Property<decimal>("EstimatedMonthlyIncome")
                                .HasPrecision(18, 2)
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("FullName")
                                .IsRequired()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)");

                            b1.Property<string>("HomeAddress")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasMaxLength(8)
                                .HasColumnType("nvarchar(8)");

                            b1.Property<string>("Rtn")
                                .HasMaxLength(14)
                                .HasColumnType("nvarchar(14)");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("WorkOrBusinessAddress")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("WorkOrBusinessDescription")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("WorkOrBusinessName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("RequestId");

                            b1.ToTable("requests");

                            b1.WithOwner()
                                .HasForeignKey("RequestId");
                        });

                    b.OwnsOne("NewVehiclePreApproval.Domain.Requests.SellerInformation", "SellerInformation", b1 =>
                        {
                            b1.Property<Guid>("RequestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Dealership")
                                .IsRequired()
                                .HasMaxLength(250)
                                .HasColumnType("nvarchar(250)");

                            b1.Property<string>("VendorName")
                                .IsRequired()
                                .HasMaxLength(200)
                                .HasColumnType("nvarchar(200)");

                            b1.HasKey("RequestId");

                            b1.ToTable("requests");

                            b1.WithOwner()
                                .HasForeignKey("RequestId");
                        });

                    b.OwnsOne("NewVehiclePreApproval.Domain.Requests.VehicleInformation", "VehicleInformation", b1 =>
                        {
                            b1.Property<Guid>("RequestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Brand")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Model")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<decimal>("Price")
                                .HasPrecision(18, 2)
                                .HasColumnType("decimal(18,2)");

                            b1.Property<string>("Type")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("Year")
                                .HasColumnType("int");

                            b1.HasKey("RequestId");

                            b1.ToTable("requests");

                            b1.WithOwner()
                                .HasForeignKey("RequestId");
                        });

                    b.Navigation("ClientInformation")
                        .IsRequired();

                    b.Navigation("SellerInformation")
                        .IsRequired();

                    b.Navigation("VehicleInformation")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
