using OrderHub.Application.DTOs;
using OrderHub.Application.Interfaces;
using OrderHub.Application.Repositoreis.Interfaces;
using OrderHub.DAL.Domain.Models;
using OrderHub.Domain.Enums;

namespace OrderHub.Application.services
{
    public sealed class OrderProcessorService : IOrderProcessorService
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IProductRepository _productRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IPaymentService _paymentService;
        private readonly IEmailService _emailService;

        public OrderProcessorService(
            ISchoolRepository schoolRepository,
            IProductRepository productRepository,
            IStockRepository stockRepository,
            IPaymentService paymentService,
            IEmailService emailService)
        {
            _schoolRepository = schoolRepository;
            _productRepository = productRepository;
            _stockRepository = stockRepository;
            _paymentService = paymentService;
            _emailService = emailService;
        }

        public async Task<ProcessOrderResult> ProcessAsync(
            int schoolId,
            IReadOnlyCollection<OrderLine>? lines,
            string parentEmail,
            CancellationToken cancellationToken = default)
        {
            var school = await _schoolRepository.GetByIdAsync(schoolId, cancellationToken);

            if (school is null)
                return ProcessOrderResult.Fail("school not found");

            decimal subtotal = 0;
            
            if (lines is null)
                lines = new List<OrderLine>();

            foreach (var line in lines)
            {
                var product = await _productRepository.GetBySkuAsync(line.Sku, cancellationToken);

                if (product is null)
                    return ProcessOrderResult.Fail($"product not found {line.Sku}");

                var stockQuantity = await _stockRepository.GetAvailableQuantityAsync(
                    line.Sku,
                    cancellationToken);

                if (stockQuantity < line.Quantity)
                    return ProcessOrderResult.Fail($"out of stock {line.Sku}");

                var price = 0m;
                if (school.TierCode == TierCodeType.Gold)
                {
                    price = product.BasePrice * 0.85m;
                }
                if (school.TierCode == TierCodeType.Silver)
                {
                    price = product.BasePrice * 0.92m;
                }
                if (!string.IsNullOrEmpty(line.Embroidery))
                {
                    if (line.Embroidery.Length <= 3)
                        price += 4.50m;

                    else
                        price += 8.00m;
                }



                subtotal += product.BasePrice * line.Quantity;
            }

            var paymentResult = await _paymentService.CreatePaymentIntentAsync(
                new PaymentIntentRequestDTO(subtotal, parentEmail),
                cancellationToken);

            if (!paymentResult.Success)
                return ProcessOrderResult.Fail("payment");

            await _emailService.SendEmailASync(
                new OrderConfirmedMessageRequestDTO(parentEmail, subtotal),
                cancellationToken);

            return ProcessOrderResult.Ok(subtotal);
        }
    }
}
