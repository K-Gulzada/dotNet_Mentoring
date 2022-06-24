using BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class ProductController : Controller
    {
        private protected IProductService _productservice;

        public ProductController(IProductService productservice)
        {
            _productservice = productservice;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var products = _productservice.GetProductList();
            return View(products);
        }
    }
}
