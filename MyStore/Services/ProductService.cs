using MyStore.Entities;
using MyStore.Repositories;

namespace MyStore.Services;

using MyStore.Models;
using System.Linq.Expressions;

public class ProductService(
    GenericRepository<Category> _categoryRepository,
    GenericRepository<Product> _productRepository,
    IWebHostEnvironment _webHostEnvironment
    )
{
    public async Task<IEnumerable<Product>> GetProducts()
    {
        var products = await _productRepository.GetAllAsync(
            includes : new Expression<Func<Product, object>>[] { p => p.Category!}
            );

        var productsVM = products.Select(p => new Product
        {
            ProductId = p.ProductId,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            Stock = p.Stock,
            ImagenName = p.ImagenName,
            CategoryId = p.CategoryId,
            Category = new CategoryVM
            {
                CategoryId = p.Category.CategoryId,
                Name = p.Category.Name
            }
        });

    }
    public async Task<Product> GetProductById(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }
    public async Task CreateProduct(Product product)
    {
        await _productRepository.AddAsync(product);
    }
    public async Task UpdateProduct(Product product)
    {
        await _productRepository.UpdateAsync(product);
    }
    public async Task DeleteProduct(int id)
    {
        await _productRepository.DeleteAsync(id);
    }
}
