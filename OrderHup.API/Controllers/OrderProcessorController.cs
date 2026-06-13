using Microsoft.AspNetCore.Mvc;
using OrderHub.Application.DTOs;
using OrderHub.Application.Interfaces;
using OrderHub.Domain.Models;

namespace OrderHup.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProcessorController : ControllerBase
    {
        private readonly IOrderProcessorService _orderProcessorService;
        public OrderProcessorController(IOrderProcessorService orderProcessorService)
        {
            _orderProcessorService = orderProcessorService;
        }
        /// <summary>
        /// Processes an order for a given school, order lines, and parent email.
        /// </summary>
        /// <param name="SchooldId">id of school</param>
        /// <param name="lines">orderlines list</param>
        /// <param name="email"> the email of parent need to send confirmation to</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ProcessOrderResult> ProcessOrder(int SchooldId=1, IReadOnlyCollection<OrderLine>? lines = null ,string email= "alaaasaleh7@gmail.com")
        {
           var res= await _orderProcessorService.ProcessAsync(SchooldId, lines, email);
            return res;
        }
    }
}
