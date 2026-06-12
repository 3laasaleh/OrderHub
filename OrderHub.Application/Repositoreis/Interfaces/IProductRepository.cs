using OrderHub.DAL.Domain;
using OrderHub.Domain.Models;


namespace OrderHub.Application.Repositoreis.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetBySkuAsync(string sku, CancellationToken cancellationToken);
    }
}
