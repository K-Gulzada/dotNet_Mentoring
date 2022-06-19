using Dapper_API.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Dapper_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Data = await _productRepository.GetProducts();
            return Ok(new
            {
                Success = true,
                Message = "All products returned.",
                Data
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product createProductDTO)
        {
            await _productRepository.Create(createProductDTO);
            return Ok(new
            {
                Success = true,
                Message = "Product item created."
            });
        }
    }
}
