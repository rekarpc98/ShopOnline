using ShopOnline.Web.Models.Entities.Products;

namespace ShopOnline.Web.Repositories.Interfaces;

public interface IProductRepository
{
	ValueTask<List<Product>> GetProductsAsync();
}