

using OrderHub.Domain.Models;

namespace OrderHub.Application.Repositoreis.Interfaces
{
    public interface IOrderLineRepository
    {
        Task<List<OrderLine>> GetOrderLinesAsync();
    }
}
