
using NSubstitute;
using OrderHub.Application.DTOs;
using OrderHub.Application.Interfaces;
using OrderHub.Application.Repositoreis.Interfaces;
using OrderHub.Application.services;
using OrderHub.Domain.Enums;
using OrderHub.Domain.Models;
using Xunit;

namespace OrderHub.UnitTesting
{
    public class OrderProcessorTests
    {
        [Fact]
        public async Task ProcessOrderAsync_WhenStockIsInsufficient_ReturnsOutOfStockFailure()
        {
            // Arrange
            var schoolRepo = Substitute.For<ISchoolRepository>();
            var productRepo = Substitute.For<IProductRepository>();
            var stockRepo = Substitute.For<IStockRepository>();
            var paymentService = Substitute.For<IPaymentService>();
            var emailService = Substitute.For<IEmailService>();
            var orderLineRepository = Substitute.For<IOrderLineRepository>();

            schoolRepo.GetByIdAsync(1, Arg.Any<CancellationToken>())
                .Returns(new School { Id = 1, TierCode = TierCodeType.Gold });

            productRepo.GetBySkuAsync("ABC-001", Arg.Any<CancellationToken>())
                .Returns(new Product { Sku = "ABC-001", BasePrice = 100m });

            //stockRepo.GetBySkuAsync("ABC-001", Arg.Any<CancellationToken>())
            //    .Returns(new Stock { Sku = "ABC-001", Quantity = 2 });

            var processor = new OrderProcessorService(
                schoolRepo,
                productRepo,
                stockRepo,
                paymentService,
                emailService,orderLineRepository);

            var lines = new List<OrderLine>
    {
        new OrderLine
        {
            Sku = "ABC-001",
            Quantity = 5,
            Embroidery = "hi"
        }
    };

            // Act
            var result = await processor.ProcessAsync(
                1,
                lines,
                "parent@test.com",
                CancellationToken.None);

            // Assert
            Assert.False(result.Success);
            Assert.Equal("FAIL: out of stock ABC-001", result.Message);
           
                 
            await paymentService.DidNotReceive()
                .CreatePaymentIntentAsync(
                   new PaymentIntentRequestDTO (Arg.Any<decimal>() ,Arg.Any<string>() ),
                    Arg.Any<CancellationToken>());
        }
    }
}
