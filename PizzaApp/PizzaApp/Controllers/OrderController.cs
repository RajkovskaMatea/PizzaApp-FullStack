namespace PizzaApp.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using PizzaApp.DTOs.OrderDTOs;
    using PizzaApp.Services.Interfaces;

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderservice;

        public OrderController(IOrderService service)
        {
            _orderservice = service;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SubmitOrder([FromBody] OrderDTO order)
        {
            await _orderservice.SubmitOrder(order);
            return Ok();
        }

        [Authorize]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllOrders(int userId)
        {
            var orders = await _orderservice.GetAllOrders(userId);
            return Ok(orders);
        }
    }
}
