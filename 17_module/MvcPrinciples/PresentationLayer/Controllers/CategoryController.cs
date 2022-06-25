using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        private protected ICategoryService _categoryService;
        private protected IConfiguration _configuration;

        public CategoryController(ICategoryService categoryService, IConfiguration configuration)
        {
            _categoryService = categoryService;
            _configuration = configuration;
        }

        public IActionResult CategoryList(int pageIndex)
        {
            int pageSize = Int32.Parse(_configuration.GetSection("PageSize").Value);
            var categories = _categoryService.GetAllCategory(pageSize, pageIndex);
            return View(categories);
        }
    }
}
