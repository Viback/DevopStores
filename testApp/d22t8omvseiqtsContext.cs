using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace testApp
{
    public partial class d22t8omvseiqtsContext : DbContext
    {
        public d22t8omvseiqtsContext()
        {
        }

        public d22t8omvseiqtsContext(DbContextOptions<d22t8omvseiqtsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Stores> Stores { get; set; }
        public virtual DbSet<Testproducts> Testproducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var cstring = Environment.GetEnvironmentVariable("DATABASE_URL"); 
                var connstr = cstring + "SslMode = Require; trust server certificate = true";
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DATABASE_URL"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("inventory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.StoreId).HasColumnName("store_id");
            });

            modelBuilder.Entity<Stores>(entity =>
            {
                entity.HasKey(e => e.StoreId);

                entity.ToTable("stores");

                entity.Property(e => e.StoreId)
                    .HasColumnName("store_id")
                    .HasDefaultValueSql("nextval('stores_prod_id_seq'::regclass)");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasColumnName("phone_no")
                    .HasMaxLength(50);

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasColumnName("store_name")
                    .HasMaxLength(50);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasColumnName("zip_code")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Testproducts>(entity =>
            {
                entity.HasKey(e => e.ProdId);

                entity.ToTable("testproducts");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.Property(e => e.ProdDesc)
                    .IsRequired()
                    .HasColumnName("prod_desc")
                    .HasMaxLength(50);

                entity.Property(e => e.ProdName)
                    .IsRequired()
                    .HasColumnName("prod_name")
                    .HasMaxLength(50);
            });

            modelBuilder.HasSequence<int>("stores_prod_id_seq");
        }
    }
}
