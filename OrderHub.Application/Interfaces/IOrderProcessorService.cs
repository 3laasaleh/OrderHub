using OrderHub.Application.DTOs;
using OrderHub.Domain.Models;
namespace OrderHub.Application.Interfaces
{
    public interface IOrderProcessorService
    {
        public  Task<ProcessOrderResult> ProcessAsync(
         int schoolId,
         IReadOnlyCollection<OrderLine>? lines,
         string parentEmail,
         CancellationToken cancellationToken = default);
    }
}
