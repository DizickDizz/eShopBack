using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Services;
using System.Text;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("orders/")]
    public class OrderController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly OrdersService _orderService;

        public OrderController(ILogger<UsersController> logger, OrdersService ordersService)
        {
            _logger = logger;
            _orderService = ordersService;
        }

        [Route("{userId:int?}/checkOut")]
        [HttpPost()]
        public IActionResult CheckOut(int userId)
        {
            return Ok(_orderService.CheckOut(userId));
        }

        [Route("{userId:int?}/getAllOrders")]
        [HttpGet()]
        public IActionResult GetAllOrders(int userId)
        {
            var orders = _orderService.GetAllOrders(userId);
            return Ok(orders);

        }
        [Route("transferTheOrder/{orderId:int?}")]
        [HttpPost()]
        public IActionResult TransferTheOrder(int orderId)
        {
            _orderService.TransferTheOrder(orderId);
            return Ok();
        }
    }
}
