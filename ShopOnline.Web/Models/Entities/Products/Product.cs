namespace ShopOnline.Web.Models.Entities.Products;

public class Product
{
	public Guid Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public string ImageUrl { get; set; } = string.Empty;
	public decimal Price { get; set; }
	public int QuantityInStock { get; set; }
	public Guid CategoryId { get; set; }
}