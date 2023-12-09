using System.Net.Http.Json;
using ShopOnline.Models.Dtos;
using ShopOnline.Models.Requests.Products;
using ShopOnline.Web.Constants;
using ShopOnline.Web.Mappers;
using ShopOnline.Web.Models.Entities.Products;
using ShopOnline.Web.Repositories.Interfaces;

namespace ShopOnline.Web.Repositories.Implementations;

public class ProductRepository(HttpClient httpClient) : IProductRepository
{
	public async ValueTask<Product> PostProductAsync(Product product)
	{
		var postProduct = new PostProduct
		{
			Name = product.Name,
			Description = product.Description,
			ImageUrl = product.ImageUrl,
			Price = product.Price,
			QuantityInStock = product.QuantityInStock,
			CategoryId = product.CategoryId
		};

		HttpResponseMessage response = await httpClient.PostAsJsonAsync(ApiRoutes.Products, postProduct);
		// todo: handle exceptions
		var productDtos = await response.Content.ReadFromJsonAsync<ProductDto>();
		
		return productDtos!.FromDto();
	}
	
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

	public async ValueTask<List<Product>> GetProductByIdAsync(Guid id)
	{
		var path = $"{ApiRoutes.Products}/{id}";
		var productDtos = await httpClient.GetFromJsonAsync<List<ProductDto>>(path);

		if (productDtos is null || productDtos.Count == 0)
		{
			return [];
		}

		IEnumerable<Product> products = productDtos.FromDtos();

		return products.ToList();
	}
}