﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataManager.Models
{
    public partial class RealEstate_AppContext : DbContext
    {
        public RealEstate_AppContext()
        {
        }

        public RealEstate_AppContext(DbContextOptions<RealEstate_AppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contract> Contracts { get; set; } = null!;
        public virtual DbSet<Landlord> Landlords { get; set; } = null!;
        public virtual DbSet<Property> Properties { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Tenant> Tenants { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-OIPLHJT;Database=RealEstate_App;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.HasIndex(e => e.PropertyId, "IX_Contracts")
                    .IsUnique();
            });

            modelBuilder.Entity<Landlord>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_Landlords")
                    .IsUnique();

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.Property(e => e.PropertyId).ValueGeneratedOnAdd();

                entity.Property(e => e.PropertyName).HasMaxLength(50);

                entity.HasOne(d => d.Landlord)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.LandlordId)
                    .HasConstraintName("FK_Properties_Landlords");

                entity.HasOne(d => d.PropertyNavigation)
                    .WithOne(p => p.Property)
                    .HasPrincipalKey<Contract>(p => p.PropertyId)
                    .HasForeignKey<Property>(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Properties_Contracts");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.TenantId)
                    .HasConstraintName("FK_Properties_Tenants");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_Tenants")
                    .IsUnique();

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Tenant)
                    .HasForeignKey<Tenant>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tenants_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedOnAdd();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.HasOne(d => d.UserNavigation)
                    .WithOne(p => p.User)
                    .HasPrincipalKey<Landlord>(p => p.UserId)
                    .HasForeignKey<User>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Landlords");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}