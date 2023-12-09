namespace ShopOnline.Api.Models.Requests.CartItems;

public class PutCartItem
{
	public Guid CartItemId { get; set; }
	public int Quantity { get; set; }
}