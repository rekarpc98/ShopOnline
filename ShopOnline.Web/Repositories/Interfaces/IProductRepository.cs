using ShopOnline.Web.Models.Entities.Products;

namespace ShopOnline.Web.Repositories.Interfaces;

public interface IProductRepository
{
	ValueTask<Product> PostProductAsync(Product product);
	ValueTask<List<Product>> GetProductsAsync();
	ValueTask<List<Product>> GetProductByIdAsync(Guid id);
}