using OrderHub.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHub.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailASync(OrderConfirmedMessageRequestDTO req, CancellationToken cancellationToken);
    }
}
