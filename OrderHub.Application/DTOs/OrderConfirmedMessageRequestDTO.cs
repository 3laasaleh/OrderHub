using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderHub.Application.DTOs
{
    public record OrderConfirmedMessageRequestDTO(string ParentEmail, decimal Subtotal);
}
