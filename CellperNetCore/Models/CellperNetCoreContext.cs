using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CellperNetCore.Models
{
    public partial class CellperNetCoreContext : DbContext
    {
        public CellperNetCoreContext()
        {
        }

        public CellperNetCoreContext(DbContextOptions<CellperNetCoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<EquipmentBrand> EquipmentBrand { get; set; }
        public virtual DbSet<EquipmentCondition> EquipmentCondition { get; set; }
        public virtual DbSet<EquipmentModel> EquipmentModel { get; set; }
        public virtual DbSet<EquipmentReception> EquipmentReception { get; set; }
        public virtual DbSet<EquipmentRepair> EquipmentRepair { get; set; }
        public virtual DbSet<EquipmentStatus> EquipmentStatus { get; set; }
        public virtual DbSet<EquipmentType> EquipmentType { get; set; }
        public virtual DbSet<FailureType> FailureType { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<MaterialInventory> MaterialInventory { get; set; }
        public virtual DbSet<SecurityUser> SecurityUser { get; set; }
        public virtual DbSet<Technician> Technician { get; set; }
        public virtual DbSet<Tenant> Tenant { get; set; }
        public virtual DbSet<Warranty> Warranty { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(200);

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.CustomerIdcard).HasColumnName("CustomerIDCard");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CustomerPhone)
                    .IsRequired()
                    .HasMaxLength(80);
            });

            modelBuilder.Entity<EquipmentBrand>(entity =>
            {
                entity.Property(e => e.EquipmentBrandId).HasColumnName("EquipmentBrandID");

                entity.Property(e => e.EquipmentBrandName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EquipmentCondition>(entity =>
            {
                entity.Property(e => e.EquipmentConditionId).HasColumnName("EquipmentConditionID");

                entity.Property(e => e.EquipmentConditionName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EquipmentModel>(entity =>
            {
                entity.Property(e => e.EquipmentModelId).HasColumnName("EquipmentModelID");

                entity.Property(e => e.EquipmentBrandId).HasColumnName("EquipmentBrandID");

                entity.Property(e => e.EquipmentModelName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EquipmentTypeId).HasColumnName("EquipmentTypeID");

                entity.HasOne(d => d.EquipmentBrand)
                    .WithMany(p => p.EquipmentModel)
                    .HasForeignKey(d => d.EquipmentBrandId)
                    .HasConstraintName("FK_EquipmentModels_EquipmentBrands");

                entity.HasOne(d => d.EquipmentType)
                    .WithMany(p => p.EquipmentModel)
                    .HasForeignKey(d => d.EquipmentTypeId)
                    .HasConstraintName("FK_EquipmentModel_EquipmentType");
            });

            modelBuilder.Entity<EquipmentReception>(entity =>
            {
                entity.Property(e => e.EquipmentReceptionId).HasColumnName("EquipmentReceptionID");

                entity.Property(e => e.Accesories).HasMaxLength(200);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.EquipmentConditionId).HasColumnName("EquipmentConditionID");

                entity.Property(e => e.EquipmentModelId).HasColumnName("EquipmentModelID");

                entity.Property(e => e.EquipmentStatusId).HasColumnName("EquipmentStatusID");

                entity.Property(e => e.FailureTypeId).HasColumnName("FailureTypeID");

                entity.Property(e => e.Imei)
                    .HasColumnName("IMEI")
                    .HasMaxLength(50);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Observations)
                    .IsRequired()
                    .HasMaxLength(1500);

                entity.Property(e => e.ReceptionDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Serial).HasMaxLength(50);

                entity.Property(e => e.TechnicianId).HasColumnName("TechnicianID");

                entity.Property(e => e.WarrantyId).HasColumnName("WarrantyID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.EquipmentReception)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentReception_Client");

                entity.HasOne(d => d.EquipmentCondition)
                    .WithMany(p => p.EquipmentReception)
                    .HasForeignKey(d => d.EquipmentConditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentReception_EquipmentCondition");

                entity.HasOne(d => d.EquipmentModel)
                    .WithMany(p => p.EquipmentReception)
                    .HasForeignKey(d => d.EquipmentModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentReception_EquipmentModel");

                entity.HasOne(d => d.EquipmentStatus)
                    .WithMany(p => p.EquipmentReception)
                    .HasForeignKey(d => d.EquipmentStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentReception_EquipmentStatus");

                entity.HasOne(d => d.FailureType)
                    .WithMany(p => p.EquipmentReception)
                    .HasForeignKey(d => d.FailureTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentReception_FailureType");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.EquipmentReception)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentReception_Location");

                entity.HasOne(d => d.Technician)
                    .WithMany(p => p.EquipmentReception)
                    .HasForeignKey(d => d.TechnicianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentReception_Technician");

                entity.HasOne(d => d.Warranty)
                    .WithMany(p => p.EquipmentReception)
                    .HasForeignKey(d => d.WarrantyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentReception_Warranty");
            });

            modelBuilder.Entity<EquipmentRepair>(entity =>
            {
                entity.Property(e => e.EquipmentRepairId).HasColumnName("EquipmentRepairID");

                entity.Property(e => e.MaterialsInventoryId).HasColumnName("MaterialsInventoryID");

                entity.Property(e => e.Observations).HasMaxLength(500);

                entity.Property(e => e.RepairDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TechnicianId).HasColumnName("TechnicianID");

                entity.HasOne(d => d.MaterialsInventory)
                    .WithMany(p => p.EquipmentRepair)
                    .HasForeignKey(d => d.MaterialsInventoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentRepair_MaterialInventory");

                entity.HasOne(d => d.Technician)
                    .WithMany(p => p.EquipmentRepair)
                    .HasForeignKey(d => d.TechnicianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentRepair_Technician");
            });

            modelBuilder.Entity<EquipmentStatus>(entity =>
            {
                entity.Property(e => e.EquipmentStatusId).HasColumnName("EquipmentStatusID");

                entity.Property(e => e.EquipmentStatusName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EquipmentType>(entity =>
            {
                entity.Property(e => e.EquipmentTypeId).HasColumnName("EquipmentTypeID");

                entity.Property(e => e.EquipmentTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<FailureType>(entity =>
            {
                entity.Property(e => e.FailureTypeId).HasColumnName("FailureTypeID");

                entity.Property(e => e.FailureTypeName)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.LocationAddress)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LocationEmail)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocationPhone)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Location)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Location_Tenant");
            });

            modelBuilder.Entity<MaterialInventory>(entity =>
            {
                entity.Property(e => e.MaterialInventoryId).HasColumnName("MaterialInventoryID");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ItemSerial).HasMaxLength(50);

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.MaterialInventory)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MaterialInventory_Location");
            });

            modelBuilder.Entity<SecurityUser>(entity =>
            {
                entity.Property(e => e.SecurityUserId).HasColumnName("SecurityUserID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.SecurityUserLogin)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityUserName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SecurityUserPassword)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.SecurityUser)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SecurityUser_Location");
            });

            modelBuilder.Entity<Technician>(entity =>
            {
                entity.Property(e => e.TechnicianId).HasColumnName("TechnicianID");

                entity.Property(e => e.TechnicianName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.Technician)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Technician_Tenant");
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.Property(e => e.TenantId).HasColumnName("TenantID");

                entity.Property(e => e.CountryId)
                    .HasColumnName("CountryID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TenanPhone)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TenantAddress)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TenantEmail)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.TenantName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenantRif)
                    .HasColumnName("TenantRIF")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Warranty>(entity =>
            {
                entity.Property(e => e.WarrantyId).HasColumnName("WarrantyID");

                entity.Property(e => e.WarrantyName)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
