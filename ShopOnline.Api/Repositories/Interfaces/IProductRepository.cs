using ShopOnline.Api.Models.Entities.Products;

namespace ShopOnline.Api.Repositories.Interfaces;

public interface IProductRepository
{
	Task<Product?> GetProductByIdAsync(Guid productId);
	Task<List<Product>> GetProductsAsync();
	Task<List<Product>> GetProductsByCategoryIdAsync(Guid categoryId);
	Task<Product> AddProductAsync(Product product);
	Task<Product> UpdateProductAsync(Product product);
}