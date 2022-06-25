using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
    public class NorthwindDbContext : DbContext
    {
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<SupplierEntity> Suppliers { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>(product => product.HasIndex(p => p.ProductID).IsUnique());
        }
    }
}
