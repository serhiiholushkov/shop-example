namespace shop.Core.Product;

public class Catalog
{
  public ICollection<Product> Products { get; set; } = [];
  public ICollection<ProductCategory> Categories { get; set; } = [];
}
