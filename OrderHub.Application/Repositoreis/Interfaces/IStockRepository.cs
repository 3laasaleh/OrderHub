using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHub.Application.Repositoreis.Interfaces
{
    public interface IStockRepository
    {
        Task<int> GetAvailableQuantityAsync(string sku, CancellationToken ct);
    }
}
