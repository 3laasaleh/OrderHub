using Microsoft.EntityFrameworkCore;
using OrderHub.Application.Repositoreis.Interfaces;
using OrderHub.Domain.Models;
using OrderHub.Infrastructure.Persistence;


namespace OrderHub.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OrderProcessorContext _context;
        public ProductRepository(OrderProcessorContext context)
        {
            _context = context;
        }
        public async Task<Product> GetBySkuAsync(string sku, CancellationToken cancellationToken)
        {
            var res= await _context.Products
                .FirstOrDefaultAsync(p => p.Sku.ToLower() == sku.ToLower(),cancellationToken);

            return res;
        }
    }
}
