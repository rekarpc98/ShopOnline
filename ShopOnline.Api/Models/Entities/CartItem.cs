using ShopOnline.Api.Models.Entities.Products;

namespace ShopOnline.Api.Models.Entities;

public class CartItem
{
	public Guid Id { get; set; }
	public Guid CartId { get; set; }
	public Cart? Cart { get; set; }
	public Guid ProductId { get; set; }
	public Product? Product { get; set; }
	public int Quantity { get; set; }
}