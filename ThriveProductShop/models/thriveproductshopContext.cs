using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ThriveProductShop.models
{
    public partial class ThriveProductShopContext : DbContext
    {
        public ThriveProductShopContext()
        {
        }

        public ThriveProductShopContext(DbContextOptions<ThriveProductShopContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<ProductGroup> ProductGroups { get; set; } = null!;
        public virtual DbSet<ProductList> ProductLists { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=ThriveProductShop;Trusted_Connection=false;integrated security=sspi;encrypt=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<ProductGroup>(entity =>
            {
                entity.ToTable("ProductGroup");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<ProductList>(entity =>
            {
                entity.ToTable("ProductList");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ImagePath).HasMaxLength(255);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductGroupId).HasColumnName("ProductGroup_Id");
                
                
                
                entity.HasOne(d => d.ProductGroup)
                    .WithMany(p => p.ProductLists)
                    .HasForeignKey(d => d.ProductGroupId)
                    .HasConstraintName("FK_ProductList_ProductGroup");
            });
            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
