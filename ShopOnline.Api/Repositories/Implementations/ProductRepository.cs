using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Data;
using ShopOnline.Api.Models.Entities.Products;
using ShopOnline.Api.Repositories.Interfaces;

namespace ShopOnline.Api.Repositories.Implementations;

public class ProductRepository(AppDbContext context) : IProductRepository
{
	public async Task<Product?> GetProductByIdAsync(Guid productId) =>
		await context.Products.FirstOrDefaultAsync(p => p.Id == productId);

	public async Task<List<Product>> GetProductsAsync() => await context.Products.ToListAsync();

	public async Task<List<Product>> GetProductsByCategoryIdAsync(Guid categoryId) =>
		await context.Products.Where(pc => pc.CategoryId == categoryId).ToListAsync();

	public async Task<Product> AddProductAsync(Product product)
	{
		await context.Products.AddAsync(product);
		await context.SaveChangesAsync();

		return product;
	}

	public async Task<Product> UpdateProductAsync(Product product)
	{
		context.Products.Update(product);
		await context.SaveChangesAsync();

		return product;
	}
}