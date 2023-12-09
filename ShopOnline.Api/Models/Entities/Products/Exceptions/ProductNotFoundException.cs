namespace ShopOnline.Api.Models.Entities.Products.Exceptions;

public class ProductNotFoundException(Guid id) : Exception($"Product with id: '{id}' was not found.");