using Microsoft.AspNetCore.Mvc;
using MyStore.Services;

namespace MyStore.Controllers
{
    public class CategoryController(CategoryService _categoryService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }
    }
}
