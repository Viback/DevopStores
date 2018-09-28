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

        public virtual DbSet<Testproducts> Testproducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=ec2-174-129-35-61.compute-1.amazonaws.com;Port=5432;Database=d22t8omvseiqts;Username=ptzhigowuibpbo;Password=c56bbb7562dae77969cdf1eb039cc999dc718e54b3b41c70832bea28ab3c3deb; SslMode=Require; trust server certificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
        }
    }
}
