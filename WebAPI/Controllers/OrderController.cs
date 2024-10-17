using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Services.OrderServices;
using Product.Services.OrderServices.DTO;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrderController : ControllerBase
    {
        private readonly IOrderService _order;
        public OrderController(IOrderService order)
        {
            _order = order;
        }
        [HttpPost]
        public async Task<ActionResult<OrderItemDTO>> CreateOrderAsync(OrderDTO input)
        {
            var order = await _order.createOrderDetials(input);
            return Ok(order);
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderItemDTO>>> GetAllOrderUserAsync()
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var orders = await _order.GetAllOrdersForUser(Email);
            return Ok(orders);
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderItemDTO>>> GetAllOrderUserbyID(Guid Id)
        {
            var orders = await _order.GetOrderIdAsync(Id);
            return Ok(orders);
        }
        [HttpGet]
        public async Task<ActionResult<OrderItemDTO>> GetAllDeilveryMethods()
        {
            return Ok(await _order.GetDeliveryStatus());
        }
    }
}
