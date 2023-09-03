using System;
using System.Collections.Generic;
using CarCollectionWeb.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarCollectionWeb.Data;

public partial class MotorShowDbContext : DbContext
{
    public MotorShowDbContext()
    {
    }

    public MotorShowDbContext(DbContextOptions<MotorShowDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarCategory> CarCategorys { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-TQCEEP1\\SPOCK_SQL2019;Database=MotorShowDB;Trusted_Connection=True; trustservercertificate=yes");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasIndex(e => e.CarCategoryId, "IX_Cars_CarCategoryId");

            object value = entity.HasOne(d => d.CarCategory).WithMany(p => p.Cars).HasForeignKey(d => d.CarCategoryId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
