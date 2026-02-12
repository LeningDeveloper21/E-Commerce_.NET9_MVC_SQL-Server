using MyStore.Context;
using MyStore.Entities;
using MyStore.Models;
using MyStore.Repositories;

namespace MyStore.Services
{
    public class CategoryService(GenericRepository<Category> _categoryRepository)
    {
        public async Task<IEnumerable<CategoryVM>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            var categoryVMs = categories.Select(c => new CategoryVM
            {
                CategoryId = c.CategoryId,
                Name = c.Name
            }).ToList();

            return categoryVMs;
        }
    }
}
