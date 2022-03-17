using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HMS.DomainLayer.Models
{
    public partial class HMSDBContext : DbContext
    {
        public HMSDBContext()
        {
        }

        public HMSDBContext(DbContextOptions<HMSDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RoomDetail> RoomDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HMSDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<RoomDetail>(entity =>
            {
                entity.HasKey(e => e.Roomnumber)
                    .HasName("PK__RoomDeta__20A5E499C50A52B5");

                entity.ToTable("RoomDetail");

                entity.Property(e => e.Roomnumber)
                    .ValueGeneratedNever()
                    .HasColumnName("roomnumber");

                entity.Property(e => e.Roomstatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("roomstatus");

                entity.Property(e => e.Roomtype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("roomtype");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
