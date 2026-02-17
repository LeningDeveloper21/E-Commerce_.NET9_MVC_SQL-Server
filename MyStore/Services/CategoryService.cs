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

        public async Task<CategoryVM?> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            var categoryVM = new CategoryVM();


            if (category != null)
            {
                categoryVM.CategoryId = category.CategoryId;
                categoryVM.Name = category.Name;
            }

            return categoryVM;
        }

        public async Task AddAsync(CategoryVM categoryVM)
        {
            var category = new Category
            {
                Name = categoryVM.Name
            };
            await _categoryRepository.AddAsync(category);
        }

        public async Task UpdateAsync(int id, CategoryVM categoryVM)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category != null)
            {
                category.Name = categoryVM.Name;
                await _categoryRepository.UpdateAsync(category);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category != null)
            {
                await _categoryRepository.DeleteAsync(category);
            }
        }

     
    }
}
