using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Services;
using System.Text;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("main/")]
    public class MainController : ControllerBase
    {
        private readonly ILogger<MainController> _logger;
        private readonly ProductService _productService;

        public MainController(ILogger<MainController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }



        [Route("getProductList")]
        [HttpGet()]
        public IActionResult GetAllProducts()
        {     
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

    }
}