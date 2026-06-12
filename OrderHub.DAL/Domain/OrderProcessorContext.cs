using Microsoft.EntityFrameworkCore;
using OrderHub.DAL.Domain.Models;

namespace OrderHub.DAL.Domain
{
    public class OrderProcessorContext : DbContext
    {
        public OrderProcessorContext(DbContextOptions<OrderProcessorContext> options) : base(options)
        { }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Stock> Stocks => Set<Stock>();
        public DbSet<School> Schools => Set<School>();
        public DbSet<OrderLine> OrderLines => Set<OrderLine>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<School>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(p => p.Stock)
                      .WithMany(s => s.Products)
                      .HasForeignKey(p => p.StockId);
            });
            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
        }

        
    }
}
