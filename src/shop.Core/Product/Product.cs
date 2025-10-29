namespace shop.Core.Product;

public class Product
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public string? Description { get; set; }
  public decimal Price { get; set; }

  // Quantity available in stock
  public int AvailableItemsInStock { get; set; }

  public int CategoryId { get; set; }
  public ProductCategory? Category { get; set; }
  public List<ProductReview> Reviews { get; set; } = [];
}
