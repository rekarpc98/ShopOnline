namespace ShopOnline.Models.Requests.CartItems;

public class PutCartItem
{
	public Guid CartItemId { get; set; }
	public int Quantity { get; set; }
}