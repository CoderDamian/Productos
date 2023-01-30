using Microsoft.AspNetCore.Mvc;
using MyProduct.AppServices.Contracts;
using MyProduct.AppServices.DTOs;

namespace MyProduct.RESTful.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            this._productService = productService;
        }

        [HttpDelete("{ID}")]
        public async Task Delete(int ID)
        {
            await _productService.DeleteAsync(ID)
                .ConfigureAwait(false); 

            await _productService.SaveAsync()
                .ConfigureAwait(false);
        }

        [HttpGet]
        public async Task<IEnumerable<ListProductsDTO>> Get()
        {
            return await _productService.GetAllAsync()
                .ConfigureAwait(false);
        }

        [HttpGet("{ID}")]
        public async Task<UpdateProductDTO> GetByID(int id)
        {
            return await _productService.GetByIDAsync(id)
                .ConfigureAwait(false);
        }

        [HttpPost]
        public async Task Save([FromBody] CreateProductDTO createProductDTO)
        {
            await _productService.AddAsync(createProductDTO)
                .ConfigureAwait(false);

            await _productService.SaveAsync()
                .ConfigureAwait(false);
        }

        [HttpPut("{ID}")]
        public async Task Update([FromBody] UpdateProductDTO updateProductDTO, int ID)
        {
            await _productService.UpdateAsync(ID, updateProductDTO)
                .ConfigureAwait(false);

            await _productService.SaveAsync()
                .ConfigureAwait(false);
        }
    }
}