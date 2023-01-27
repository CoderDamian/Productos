using Microsoft.AspNetCore.Mvc;
using MyProduct.AppServices.Contracts;
using MyProduct.AppServices.DTOs;

namespace MyProduct.RESTful.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            this._productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<ListProductsDTO>> Get()
        {
            return await _productService.GetAllAsync().ConfigureAwait(false);
        }
    }
}