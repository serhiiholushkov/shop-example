namespace shop.Core.Product;

public class ProductReview
{
  public int Id { get; set; }
  public int Rating { get; set; } // e.g., 1 to 5
  public string? Comment { get; set; }
  public DateTime Created { get; set; }

  public int ProductId { get; set; }
  public Product Product { get; set; } = default!;

  // TODO: Add Reviewer information (e.g., UserId, Name) if needed.
}
