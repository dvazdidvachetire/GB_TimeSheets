﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TimeSheets.DAL.Repositories.Context;

namespace TimeSheets.Migrations
{
    [DbContext(typeof(DbContextRepository))]
    partial class DbContextRepositoryModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("TimeSheets.DAL.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<int>("IsDelete")
                        .HasColumnType("integer");

                    b.Property<int>("NumberContract")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("TimeSheets.DAL.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("TimeSheets.DAL.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("TimeSheets.DAL.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("TimeSheets.DAL.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int?>("ContractId")
                        .HasColumnType("integer");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("InvoiceId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("TimeSheets.DAL.Models.TimeSheet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("FromTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("JobId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("ToTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("JobId");

                    b.ToTable("TimeSheets");
                });

            modelBuilder.Entity("TimeSheets.DAL.Models.Contract", b =>
                {
                    b.HasOne("TimeSheets.DAL.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("TimeSheets.DAL.Models.Job", b =>
                {
                    b.HasOne("TimeSheets.DAL.Models.Contract", null)
                        .WithMany("Jobs")
                        .HasForeignKey("ContractId");

                    b.HasOne("TimeSheets.DAL.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("TimeSheets.DAL.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("TimeSheets.DAL.Models.Invoice", null)
                        .WithMany("Jobs")
                        .HasForeignKey("InvoiceId");

                    b.Navigation("Customer");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("TimeSheets.DAL.Models.TimeSheet", b =>
                {
                    b.HasOne("TimeSheets.DAL.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId");

                    b.HasOne("TimeSheets.DAL.Models.Job", null)
                        .WithMany("TimeSheets")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("TimeSheets.DAL.Models.Contract", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("TimeSheets.DAL.Models.Invoice", b =>
                {
                    b.Navigation("Jobs");
                });

            modelBuilder.Entity("TimeSheets.DAL.Models.Job", b =>
                {
                    b.Navigation("TimeSheets");
                });
#pragma warning restore 612, 618
        }
    }
}
