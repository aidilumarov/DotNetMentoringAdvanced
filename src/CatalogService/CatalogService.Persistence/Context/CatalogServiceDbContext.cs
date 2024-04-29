using CatalogService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Persistence.Context
{
    public class CatalogServiceDbContext : DbContext
    {
        public CatalogServiceDbContext(DbContextOptions<CatalogServiceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null) return;

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Subcategories)
                .WithOne(c => c.ParentCategory)
                .HasForeignKey(c => c.ParentCategoryId);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.Category)
                .WithMany(c => c.Items)
                .HasForeignKey(i => i.CategoryId)
                .IsRequired();
        }
    }
}
