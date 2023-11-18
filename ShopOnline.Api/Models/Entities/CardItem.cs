namespace ShopOnline.Api.Models.Entities;

public class CardItem
{
	public Guid Id { get; set; }
	public Guid CardId { get; set; }
	public Guid ProductId { get; set; }
	public int Quantity { get; set; }
}