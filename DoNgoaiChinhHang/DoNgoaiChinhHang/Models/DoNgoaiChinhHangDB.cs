using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DoNgoaiChinhHang.Models
{
    public partial class DoNgoaiChinhHangDB : DbContext
    {
        public DoNgoaiChinhHangDB()
            : base("name=DoNgoaiChinhHangDB")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryBase> CategoryBases { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryBaseID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Images)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.CategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products1)
                .WithRequired(e => e.Category1)
                .HasForeignKey(e => e.CategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CategoryBase>()
                .Property(e => e.CategoryBaseID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CategoryBase>()
                .Property(e => e.Images)
                .IsUnicode(false);

            modelBuilder.Entity<CategoryBase>()
                .HasMany(e => e.Categories)
                .WithRequired(e => e.CategoryBase)
                .HasForeignKey(e => e.CategoryBaseID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CategoryBase>()
                .HasMany(e => e.Categories1)
                .WithRequired(e => e.CategoryBase1)
                .HasForeignKey(e => e.CategoryBaseID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.CategoryID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Image)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Brand)
                .IsUnicode(false);
        }
    }
}
