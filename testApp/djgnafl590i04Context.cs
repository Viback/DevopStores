using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace testApp
{
    public partial class djgnafl590i04Context : DbContext
    {
        public djgnafl590i04Context()
        {
        }

        public djgnafl590i04Context(DbContextOptions<djgnafl590i04Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Stores> Stores { get; set; }

        // Unable to generate entity type for table 'public.inventory'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Server = ec2-54-75-239-237.eu-west-1.compute.amazonaws.com; Port = 5432; Database = djgnafl590i04; Username = zqjjctnlwmlbhi; Password = 6f9c3f7cc013ed68bf34c263b65638d0ab97ebce95145f69ca2c1175518c7998; SslMode = Require; trust server certificate = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.HasSequence<int>("stores_prod_id_seq");
        }
    }
}
