namespace ShopOnline.Models.Requests.Products;

public class PostProduct
{
	public string Name { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public string ImageUrl { get; set; } = string.Empty;
	public decimal Price { get; set; }
	public int QuantityInStock { get; set; }
	public Guid CategoryId { get; set; }
}