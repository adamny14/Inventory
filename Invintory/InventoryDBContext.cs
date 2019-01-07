using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Invintory
{
    public partial class InventoryDBContext : DbContext
    {
        public InventoryDBContext()
        {
        }

        public InventoryDBContext(DbContextOptions<InventoryDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=InventoryDB;Username=postgres;Password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Items>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdditionalData)
                    .HasColumnName("Additional_Data")
                    .HasColumnType("jsonb");

                entity.Property(e => e.Color).HasColumnType("character varying(64)");

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasColumnType("character varying(128)");

                entity.Property(e => e.DatePurchased)
                    .HasColumnName("Date_Purchased")
                    .HasColumnType("date");

                entity.Property(e => e.Location).HasColumnType("character varying(128)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying(128)");

                entity.Property(e => e.Serial).HasColumnType("character varying(128)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("character varying(64)");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Color).HasColumnType("character varying(64)");

                entity.Property(e => e.Company).HasColumnType("character varying(128)");

                entity.Property(e => e.DatePurchased)
                    .HasColumnName("Date_Purchased")
                    .HasColumnType("date");

                entity.Property(e => e.Location).HasColumnType("character varying(128)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying(128)");

                entity.Property(e => e.Type).HasColumnType("character varying(128)");
            });
        }
    }
}
