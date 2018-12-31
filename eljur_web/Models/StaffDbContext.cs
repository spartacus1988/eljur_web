using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eljur_web.Models
{
    public partial class StaffDbContext : DbContext
    {
        public StaffDbContext()
        {
        }

        public StaffDbContext(DbContextOptions<StaffDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<Pupils> Pupils { get; set; }
        public virtual DbSet<Schedules> Schedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-I43QIPT\\SQLEXPRESS;Database=StaffDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Events>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.Property(e => e.EventName).HasMaxLength(500);
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey });

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Pupils>(entity =>
            {
                entity.HasKey(e => e.PupilId);

                entity.Property(e => e.Clas).HasMaxLength(10);

                entity.Property(e => e.FirstName).HasMaxLength(500);

                entity.Property(e => e.FullFio)
                    .HasColumnName("FullFIO")
                    .HasMaxLength(1000);

                entity.Property(e => e.LastName).HasMaxLength(500);

                entity.Property(e => e.MiddleName).HasMaxLength(500);
            });

            modelBuilder.Entity<Schedules>(entity =>
            {
                entity.HasKey(e => e.ScheduleId);

                entity.Property(e => e.Clas).HasMaxLength(10);
            });
        }
    }
}
