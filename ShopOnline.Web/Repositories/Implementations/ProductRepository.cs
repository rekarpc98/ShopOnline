using System.Net.Http.Json;
using ShopOnline.Models.Dtos;
using ShopOnline.Web.Constants;
using ShopOnline.Web.Mappers;
using ShopOnline.Web.Models.Entities.Products;
using ShopOnline.Web.Repositories.Interfaces;

namespace ShopOnline.Web.Repositories.Implementations;

public class ProductRepository(HttpClient httpClient) : IProductRepository
{
	public async ValueTask<List<Product>> GetProductsAsync()
	{
		var productDtos = await httpClient.GetFromJsonAsync<List<ProductDto>>(ApiRoutes.Products);

		if (productDtos is null || productDtos.Count == 0)
		{
			return [];
		}
		
		IEnumerable<Product> products = productDtos.FromDtos();
		
		return products.ToList();
	}
}