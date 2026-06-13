using OrderHub.Application.DTOs;
using OrderHub.Application.Interfaces;


namespace OrderHub.Application.services
{
    public class PaymentService : IPaymentService
    {
        public async Task<PaymentIntentResponseDTO> CreatePaymentIntentAsync(PaymentIntentRequestDTO req, CancellationToken cancellationToken)
        {
			try
			{
                var http = new HttpClient();
                var body = "amount=" + req.Subtotal + "&email=" + req.ParentEmail;
                var payRes = await http.PostAsync("https://api.paymentprovider.com/intents", new StringContent(body));
                if (!payRes.IsSuccessStatusCode)

                    return
                        new PaymentIntentResponseDTO { Message = "FAIL: payment" };

                else
                    return new PaymentIntentResponseDTO { Message = "OK" };
            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}
