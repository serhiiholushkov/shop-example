namespace shop.Core.Product;

public class Product : EntityBase<int>, IAggregateRoot
{
  public required string Name { get; set; }
  public string? Description { get; set; }
  public decimal Price { get; set; }

  // Quantity available in stock
  public int AvailableItemsInStock { get; set; }

  public int CategoryId { get; set; }
  public ProductCategory Category { get; set; } = default!;
  public ICollection<ProductReview> Reviews { get; set; } = [];
}
