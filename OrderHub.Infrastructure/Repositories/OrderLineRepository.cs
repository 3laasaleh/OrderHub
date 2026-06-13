using Microsoft.EntityFrameworkCore;
using OrderHub.Application.Repositoreis.Interfaces;
using OrderHub.Domain.Models;
using OrderHub.Infrastructure.Persistence;


namespace OrderHub.Infrastructure.Repositories
{
    public class OrderLineRepository : IOrderLineRepository
    {
        private readonly OrderProcessorContext _context;

        public OrderLineRepository(OrderProcessorContext context )
        {
            _context= context;
        }
        public async Task<List<OrderLine>> GetOrderLinesAsync()
        {
          var lines = await _context.OrderLines.ToListAsync();
          return lines;
        }

     
   
    }
}
