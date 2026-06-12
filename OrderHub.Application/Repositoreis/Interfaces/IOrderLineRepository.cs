using OrderHub.DAL.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHub.Application.Repositoreis.Interfaces
{
    public interface IOrderLineRepository
    {
        Task<List<OrderLine>> GetOrderLinesAsync();
    }
}
