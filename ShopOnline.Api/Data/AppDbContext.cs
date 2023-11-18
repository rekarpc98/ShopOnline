using Microsoft.EntityFrameworkCore;
using ShopOnline.Api.Models.Entities;

namespace ShopOnline.Api.Data;

public class AppDbContext(IConfiguration configuration) : DbContext
{
	public DbSet<User> Users { get; set; } = default!;
	public DbSet<Product> Products { get; set; } = default!;
	public DbSet<Card> Cards { get; set; } = default!;
	public DbSet<ProductCategory> ProductCategories { get; set; } = default!;
	public DbSet<CardItem> CardItems { get; set; } = default!;

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		string? connectionString = configuration.GetConnectionString("DefaultConnection");
		ArgumentException.ThrowIfNullOrEmpty(connectionString, nameof(connectionString));
		optionsBuilder.UseSqlServer(connectionString);
	}
}