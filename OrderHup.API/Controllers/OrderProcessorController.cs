using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderHub.Application.DTOs;
using OrderHub.Application.Interfaces;

namespace OrderHup.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProcessorController : ControllerBase
    {
        private readonly ILogger<OrderProcessorController> _logger;

        private readonly IOrderProcessorService _orderProcessorService;

        public OrderProcessorController(ILogger<OrderProcessorController> logger, IOrderProcessorService orderProcessorService)
        {
            _logger = logger;
            _orderProcessorService = orderProcessorService;
        }
        [HttpGet]
        public async Task<ProcessOrderResult> ProcessOrder()
        {
           var res= await _orderProcessorService.ProcessAsync(1,null,"alaaasaleh7@gmail.com");

            return res;
        }
    }
}
