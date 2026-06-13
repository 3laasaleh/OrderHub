using Microsoft.EntityFrameworkCore;
using OrderHub.Application.Repositoreis.Interfaces;
using OrderHub.Infrastructure.Persistence;

namespace OrderHub.Infrastructure.Repositories
{
    public class StockRepository:IStockRepository
    {
        private readonly OrderProcessorContext _context;
        public StockRepository(OrderProcessorContext context)
        {
            _context = context;
        }
        public async Task<long> GetAvailableQuantityAsync(string sku, CancellationToken ct) {

            var stock = await _context.Stocks.FirstOrDefaultAsync(s=>s.Sku.ToLower()==sku.ToLower(), ct);

            return stock?.Quantity ?? 0;


        }
    }

  
}
