using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Mappers;
using ShopOnline.Api.Models.Entities.Products;
using ShopOnline.Api.Models.Entities.Products.Exceptions;
using ShopOnline.Api.Services.Interfaces;
using ShopOnline.Models.Dtos;
using ShopOnline.Models.Requests.Products;

namespace ShopOnline.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
	[HttpGet]
	public async Task<IActionResult> GetProducts()
	{
		try
		{
			List<Product> products = await productService.GetProductsAsync();
			IEnumerable<ProductDto> dtos = products.ToProductsDto();
			
			return Ok(dtos);
		}
		catch (ProductNotFoundException)
		{
			return NotFound();
		}
		catch (Exception)
		{
			return StatusCode(500);
		}
	}
	
	[HttpGet("{id}")]
	public async Task<IActionResult> GetProduct(Guid id)
	{
		try
		{
			Product product = await productService.GetProductByIdAsync(id);
			var dto = product.ToProductDto();
			
			return Ok(dto);
		}
		catch (ProductNotFoundException)
		{
			return NotFound();
		}
		catch (Exception)
		{
			return StatusCode(500);
		}
	}

	[HttpPost]
	public async Task<IActionResult> PostProduct([FromBody] PostProduct postProduct)
	{
		try
		{
			Product addedProduct = await productService.CreateProductAsync(postProduct);

			return Ok(addedProduct);
		}
		catch (Exception)
		{
			return StatusCode(500);
		}
	}
}