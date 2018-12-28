using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
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

        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Electronics> Electronics { get; set; }
        public virtual DbSet<Movies> Movies { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Vehicles> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=InventoryDB;Username=postgres;Password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.Property(e => e.BookId).HasColumnName("Book_ID");

                entity.Property(e => e.Author).HasColumnType("character varying(128)");

                entity.Property(e => e.CopyRightDate)
                    .HasColumnName("Copy_Right_Date")
                    .HasColumnType("date");

                entity.Property(e => e.Isbn)
                    .HasColumnName("ISBN")
                    .HasColumnType("character varying(128)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("Product_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Publisher).HasColumnType("character varying(64)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_ID");
            });

            modelBuilder.Entity<Electronics>(entity =>
            {
                entity.Property(e => e.ElectronicsId).HasColumnName("Electronics_ID");

                entity.Property(e => e.Accessories).HasColumnType("json");

                entity.Property(e => e.MacAddrs).HasColumnName("Mac_Addrs");

                entity.Property(e => e.ProductId)
                    .HasColumnName("Product_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.StorageGb).HasColumnName("Storage_GB");

                entity.Property(e => e.Type).HasColumnType("character varying(64)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Electronics)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Electronics_Product_ID_fkey");
            });

            modelBuilder.Entity<Movies>(entity =>
            {
                entity.HasKey(e => e.MovieId);

                entity.Property(e => e.MovieId).HasColumnName("Movie_ID");

                entity.Property(e => e.Director).HasColumnType("character varying(128)");

                entity.Property(e => e.Medium).HasColumnType("character varying(64)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("Product_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RunTimeMin).HasColumnName("Run_Time_Min");

                entity.Property(e => e.Serial).HasColumnType("character varying(128)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Movies)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Movies_Product_ID_fkey");
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

            modelBuilder.Entity<Vehicles>(entity =>
            {
                entity.HasKey(e => e.VehicleId);

                entity.Property(e => e.VehicleId).HasColumnName("Vehicle_ID");

                entity.Property(e => e.MillageAtPurchase).HasColumnName("Millage_At_Purchase");

                entity.Property(e => e.ProductId)
                    .HasColumnName("Product_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Type).HasColumnType("character varying(64)");

                entity.Property(e => e.Vin)
                    .HasColumnName("VIN")
                    .HasColumnType("character varying(128)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Primary_Key");
            });
        }
    }
}
