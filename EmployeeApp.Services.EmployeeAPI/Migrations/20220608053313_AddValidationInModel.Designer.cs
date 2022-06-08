﻿// <auto-generated />
using System;
using EmployeeApp.Services.EmployeeAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeApp.Services.EmployeeAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220608053313_AddValidationInModel")]
    partial class AddValidationInModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmployeeApp.Services.EmployeeAPI.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"), 1L, 1);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("PersonnelNumber")
                        .HasColumnType("int");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<bool>("RegularOrExternal")
                        .HasColumnType("bit");

                    b.HasKey("EmployeeId");

                    b.HasIndex("PositionId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            DateOfBirth = new DateTime(1990, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FIO = "N.A.Ivanov",
                            PersonnelNumber = 11111,
                            PositionId = 2,
                            RegularOrExternal = false
                        },
                        new
                        {
                            EmployeeId = 2,
                            DateOfBirth = new DateTime(1985, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FIO = "A.G.Petrov",
                            PositionId = 1,
                            RegularOrExternal = true
                        });
                });

            modelBuilder.Entity("EmployeeApp.Services.EmployeeAPI.Models.Position", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PositionId"), 1L, 1);

                    b.Property<double>("BaseSalary")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PositionId");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            PositionId = 1,
                            BaseSalary = 15000.0,
                            Name = "Worker"
                        },
                        new
                        {
                            PositionId = 2,
                            BaseSalary = 50000.0,
                            Name = "Director"
                        });
                });

            modelBuilder.Entity("EmployeeApp.Services.EmployeeAPI.Models.Employee", b =>
                {
                    b.HasOne("EmployeeApp.Services.EmployeeAPI.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Position");
                });
#pragma warning restore 612, 618
        }
    }
}
