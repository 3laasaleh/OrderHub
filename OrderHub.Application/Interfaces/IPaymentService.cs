using OrderHub.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHub.Application.Interfaces
{
    public interface IPaymentService
    {
        Task<PaymentIntentResponseDTO> CreatePaymentIntentAsync(PaymentIntentRequestDTO req, CancellationToken cancellationToken);
    }
}
