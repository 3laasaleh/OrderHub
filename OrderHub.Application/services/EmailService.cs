using Microsoft.Extensions.Configuration;
using OrderHub.Application.DTOs;
using OrderHub.Application.Interfaces;

using System.Net.Mail;


namespace OrderHub.Application.services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailASync(OrderConfirmedMessageRequestDTO req, CancellationToken cancellationToken)
        {
            try
            {
                var SmtpHost = _configuration["SmtpHost"];
                var smtp = new SmtpClient(SmtpHost);
                await smtp.SendMailAsync("orders@brindleford.co.uk", req.ParentEmail, "Order confirmed", "Your order total is £" + req.Subtotal,cancellationToken);

            }
            catch (Exception e)
            {
                // should add logger here
                throw ;
            }
        }
    }
}
