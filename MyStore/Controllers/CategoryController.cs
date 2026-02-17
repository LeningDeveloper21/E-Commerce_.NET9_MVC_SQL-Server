using Microsoft.AspNetCore.Mvc;
using MyStore.Models;
using MyStore.Services;

namespace MyStore.Controllers
{
    public class CategoryController(CategoryService _categoryService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> AddEdit(int id)
        {
            var categoryVm = await _categoryService.GetByIdAsync(id);
            return View(categoryVm);
        }

        [HttpPost]
        public async Task<IActionResult> AddEdit(CategoryVM entityVm)
        {
            ViewBag.Message = null;
            if (!ModelState.IsValid) return View(entityVm);

            if (entityVm.CategoryId == 0)
            {
                await _categoryService.AddAsync(entityVm);
                ModelState.Clear();
                entityVm = new CategoryVM();
                ViewBag.Message = "Category added successfully!";
            }
            else
            {
                await _categoryService.UpdateAsync(entityVm.CategoryId, entityVm);
                ViewBag.Message = "Category updated successfully!";
            }


            return View(entityVm);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
