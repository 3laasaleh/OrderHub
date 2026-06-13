

namespace OrderHub.Application.Repositoreis.Interfaces
{
    public interface IStockRepository
    {
        Task<long> GetAvailableQuantityAsync(string sku, CancellationToken ct);
    }
}
