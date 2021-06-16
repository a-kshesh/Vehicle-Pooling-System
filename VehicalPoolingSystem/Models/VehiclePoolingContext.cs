using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VehicalPoolingSystem.Models
{
    public partial class VehiclePoolingContext : DbContext
    {
        public VehiclePoolingContext()
        {
        }

        public VehiclePoolingContext(DbContextOptions<VehiclePoolingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vehicles> Vehicles { get; set; }
        public virtual DbSet<Bookings> Bookings { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;database=VehiclePooling;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Users__1788CC4C85F67E8E");

                entity.Property(e => e.UserId)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(360)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bookings>(entity => 
            {
                entity.HasKey(e => e.BookingId);
                entity.Property(e => e.BookingId)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.VehicleId)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.UserId)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.PickupAddress)
                    .HasMaxLength(360)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vehicles>(entity =>
            {
                entity.HasKey(e => e.VehicleId)
                    .HasName("PK__Vehicles__476B549222258F21");

                entity.Property(e => e.VehicleId)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Image1Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Image2Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Image3Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsuranceDocFileName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InsuranceNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LicenseNumber)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ManufacturingYear)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OwnershipDocFileName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PickupAddress)
                    .HasMaxLength(360)
                    .IsUnicode(false);
                
                entity.Property(e => e.PickupCity)
                   .HasMaxLength(30)
                   .IsUnicode(false);
                
                entity.Property(e => e.PickupState)
                   .HasMaxLength(30)
                   .IsUnicode(false);

                entity.Property(e => e.PickupZipCode)
                   .HasMaxLength(30)
                   .IsUnicode(false);

                entity.Property(e => e.VehicleIgnition)
                   .HasMaxLength(30)
                   .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleTransmission)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserId_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
