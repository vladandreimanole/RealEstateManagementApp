using System;
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
        public virtual DbSet<Property> Properties { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<UploadedImage> UploadedImages { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-I15KRP2\\KPIMAILER;Database=RealEstate_App;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contract>(entity =>
            {
                entity.HasIndex(e => e.PropertyId, "IX_Contracts_1")
                    .IsUnique();

                entity.HasOne(d => d.Property)
                    .WithOne(p => p.Contract)
                    .HasForeignKey<Contract>(d => d.PropertyId)
                    .HasConstraintName("FK_Contracts_Properties");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.TenantId)
                    .HasConstraintName("FK_Contracts_Users");
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.Property(e => e.PropertyName).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Properties_Users");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<UploadedImage>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.UploadedImages)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UploadedImages_Properties");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
