using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Models.Entities;
using ShopOnline.Api.Models.Entities.Products;

namespace ShopOnline.Api.Data;

public class AppDbContext(IConfiguration configuration) : DbContext
{
	public DbSet<User> Users { get; set; } = default!;
	public DbSet<Product> Products { get; set; } = default!;
	public DbSet<Cart> Carts { get; set; } = default!;
	public DbSet<ProductCategory> ProductCategories { get; set; } = default!;
	public DbSet<CartItem> CartItems { get; set; } = default!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		User[] users = SeedUser();
		modelBuilder.Entity<User>().HasData(users);
		modelBuilder.Entity<Product>().HasData(SeedProduct());
		modelBuilder.Entity<Cart>().HasData(SeedCart(users));
		modelBuilder.Entity<ProductCategory>().HasData(SeedProductCategory());
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		string? connectionString = configuration.GetConnectionString("DefaultConnection");
		ArgumentException.ThrowIfNullOrEmpty(connectionString, nameof(connectionString));
		optionsBuilder.UseSqlServer(connectionString);
	}

	private static User[] SeedUser()
	{
		User[] list = Enumerable.Range(start: 1, count: 5)
			.Select(i => new User { Id = Guid.NewGuid(), Username = $"User{i}" })
			.ToArray();

		return list;
	}

	private static IEnumerable<Product> SeedProduct()
	{
		IEnumerable<Product> list = Enumerable.Range(start: 1, count: 5)
			.Select(
				i => new Product
				{
					Id = Guid.NewGuid(),
					Name = $"Product{i}",
					Description = $"Description for Product{i}",
					ImageUrl = $"Image{i}.png",
					Price = 10.99m + i,
					QuantityInStock = 50 + i,
					CategoryId = Guid.NewGuid()
				}
			);

		return list;
	}

	private static IEnumerable<Cart> SeedCart(IReadOnlyList<User> users)
	{
		IEnumerable<Cart> list = Enumerable.Range(start: 0, count: 4)
			.Select(i => new Cart { Id = Guid.NewGuid(), UserId = users[i].Id });

		return list;
	}

	private static IEnumerable<ProductCategory> SeedProductCategory()
	{
		IEnumerable<ProductCategory> list = Enumerable.Range(start: 1, count: 5)
			.Select(
				i => new ProductCategory
				{
					Id = Guid.NewGuid(), Name = $"Category{i}", Description = $"Description for Category{i}",
				}
			);

		return list;
	}
}