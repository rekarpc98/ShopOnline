using ShopOnline.Models.Dtos;

namespace ShopOnline.Models.Responses.Products;

public class GetProducts
{
	public List<ProductDto> Products { get; set; } = [];
}