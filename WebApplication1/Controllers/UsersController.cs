using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Services;
using System.Text;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("users/{userId:int?}")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly CartService _cartService;
        private readonly ProductService _productService;

        public UsersController(ILogger<UsersController> logger, CartService cartService, ProductService productService)
        {
            _logger = logger;
            _cartService = cartService;
            _productService = productService;
        }
        
        [Route("additem/{productId:int?}/{quantity:int?}")]
        [HttpGet]
        public IActionResult AddItem(int productId, int quantity, int userId)
        {
            var product = _productService.GetProduct(productId);

            _cartService.AddItem(product, quantity, userId);
            return Ok();
        }
        
        [Route("removeitem/{productId:int?}")]
        [HttpGet]

        public IActionResult RemoveItem(int userId, int productId)
        {
            _cartService.RemoveLine(userId,  productId);
            return Ok();
        }

        [Route("removeall")]
        [HttpGet()]

        public IActionResult RemoveAll(int userId)
        {
            _cartService.RemoveAll(userId);
            return Ok();
        }

        [Route("cart")]
        [HttpGet()]
        public IActionResult GetCart(int userId)
        {
            var CartItems = _cartService.GetCart(userId);
            return Ok(CartItems);
        }

    }
}