using Microsoft.EntityFrameworkCore;
using OrderHub.DAL.Domain.Models;
using OrderHub.Domain.Enums;
using OrderHub.Domain.Models;


namespace OrderHub.Infrastructure.Persistence
{

    public class OrderProcessorContext : DbContext
    {
        public OrderProcessorContext(
            DbContextOptions<OrderProcessorContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<School> Schools => Set<School>();
        public DbSet<Stock> Stocks => Set<Stock>();
        public DbSet<OrderLine> OrderLines => Set<OrderLine>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.Stock)
         .WithMany(x => x.Products)
         .HasForeignKey(x => x.StockId);

            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.Stock)
         .WithMany(x => x.Products)
         .HasForeignKey(x => x.StockId);

            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.HasKey(x => x.Id);


            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(x => x.Id);


            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.HasKey(x => x.Id);


            });


            modelBuilder.Entity<Product>().HasData(new Product { Id = 1, Sku = "SKU001", Name = "Product 1", StockId = 1, BasePrice = 10.00m },
                new Product { Id = 2, Sku = "SKU002", Name = "Product 2", StockId = 2, BasePrice = 15.00m },
                new Product { Id = 3, Sku = "SKU003", Name = "Product 3", StockId = 3, BasePrice = 20.00m } );

            modelBuilder.Entity<Stock>().HasData(
                new Stock { Id = 1, Quantity = 100, Sku = "SKU001" },
                new Stock { Id = 2, Quantity = 200, Sku = "SKU002" },
                new Stock { Id = 3, Quantity = 300, Sku = "SKU003" });

            modelBuilder.Entity<OrderLine>().HasData(
                new OrderLine { Id = 1,Embroidery  = "alaa", Quantity = 10, Sku = "SKU001"}, 
                new OrderLine { Id = 2, Embroidery = "star", Quantity = 20, Sku = "SKU002" },
                new OrderLine { Id = 3, Embroidery = "a", Quantity = 30, Sku = "SKU003" });

            modelBuilder.Entity<School>().HasData(
                new School { Id = 1, TierCode = TierCodeType.Silver, Name = "School Silver" },
                new School { Id = 2, TierCode = TierCodeType.Gold, Name = "School Gold" });






        }
    }
}
