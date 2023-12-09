namespace ShopOnline.Models.Requests.CartItems;

public class PostCartItem
{
	public Guid CartId { get; set; }
	public Guid ProductId { get; set; }
	public int Quantity { get; set; }
}