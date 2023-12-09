using ShopOnline.Api.Models.Entities.Products;
using ShopOnline.Api.Models.Entities.Products.Exceptions;
using ShopOnline.Api.Repositories.Interfaces;
using ShopOnline.Api.Services.Interfaces;
using ShopOnline.Models.Requests.Products;

namespace ShopOnline.Api.Services.Implementations;

public class ProductService(IProductRepository productRepository) : IProductService
{
	public async Task<Product> GetProductByIdAsync(Guid productId)
	{
		Product? product = await productRepository.GetProductByIdAsync(productId);

		if (product is null)
		{
			throw new ProductNotFoundException(productId);
		}

		return product;
	}

	public async Task<List<Product>> GetProductsAsync() => await productRepository.GetProductsAsync();

	public async Task<List<Product>> GetProductsByCategoryIdAsync(Guid categoryId) =>
		await productRepository.GetProductsByCategoryIdAsync(categoryId);

	public async Task<Product> CreateProductAsync(PostProduct postProduct)
	{
		// validate post request model

		var product = new Product
		{
			Name = postProduct.Name,
			Description = postProduct.Description,
			ImageUrl = postProduct.ImageUrl,
			Price = postProduct.Price,
			QuantityInStock = postProduct.QuantityInStock,
			CategoryId = postProduct.CategoryId
		};

		Product addedProduct = await productRepository.AddProductAsync(product);

		return addedProduct;
	}

	public async Task<Product> UpdateProductAsync(Guid productId, PutProduct putProduct)
	{
		// validate put request model
		Product? product = await productRepository.GetProductByIdAsync(productId);

		if (product is null)
		{
			throw new ProductNotFoundException(productId);
		}

		product.Name = putProduct.Name;
		product.Description = putProduct.Description;
		product.ImageUrl = putProduct.ImageUrl;
		product.Price = putProduct.Price;
		product.QuantityInStock = putProduct.QuantityInStock;
		product.CategoryId = putProduct.CategoryId;
		Product updatedProduct = await productRepository.UpdateProductAsync(product);

		return updatedProduct;
	}
}