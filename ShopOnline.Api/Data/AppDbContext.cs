using Microsoft.EntityFrameworkCore;

namespace ShopOnline.Api.Data;

public class AppDbContext(IConfiguration configuration) : DbContext
{
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		string? connectionString = configuration.GetConnectionString("DefaultConnection");
		ArgumentException.ThrowIfNullOrEmpty(connectionString, nameof(connectionString));
		optionsBuilder.UseSqlServer(connectionString);
	}
}