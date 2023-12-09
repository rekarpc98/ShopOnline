using ShopOnline.Api.Models.Entities.Products;
using ShopOnline.Api.Models.Requests.Products;

namespace ShopOnline.Api.Services.Interfaces;

public interface IProductService
{
	Task<Product> GetProductByIdAsync(Guid productId);
	Task<List<Product>> GetProductsAsync();
	Task<List<Product>> GetProductsByCategoryIdAsync(Guid categoryId);
	Task<Product> CreateProductAsync(PostProduct postProduct);
	Task<Product> UpdateProductAsync(Guid productId, PutProduct putProduct);
}