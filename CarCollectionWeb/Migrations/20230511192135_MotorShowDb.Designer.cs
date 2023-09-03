﻿// <auto-generated />
using CarCollectionWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarCollectionWeb.Migrations
{
    [DbContext(typeof(MotorShowDbContext))]
    [Migration("20230511192135_MotorShowDb")]
    partial class MotorShowDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarCollectionWeb.CarCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarCategorys");
                });

            modelBuilder.Entity("CarCollectionWeb.Models.Domain.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CarBrand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CarModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EngineСapacity")
                        .HasColumnType("int");

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CarCategoryId" }, "IX_Cars_CarCategoryId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarCollectionWeb.Models.Domain.Car", b =>
                {
                    b.HasOne("CarCollectionWeb.CarCategory", "CarCategory")
                        .WithMany("Cars")
                        .HasForeignKey("CarCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarCategory");
                });

            modelBuilder.Entity("CarCollectionWeb.CarCategory", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
