using shop.Core.Product;
using shop.Core.Shared;

namespace shop.Infrastructure.Data;

public static class SeedData
{
  public static async Task InitializeAsync(AppDbContext dbContext)
  {
    // If any products exist, assume DB is already seeded
    if (await dbContext.Products.AnyAsync()) return;

    await PopulateTestDataAsync(dbContext);
  }

  public static async Task PopulateTestDataAsync(AppDbContext dbContext)
  {
    // Categories
    var electronics = new ProductCategory { Name = "Electronics", Description = "Devices and gadgets" };
    var books = new ProductCategory { Name = "Books", Description = "Reading materials" };
    var clothing = new ProductCategory { Name = "Clothing", Description = "Apparel and accessories" };

    // Products
    var smartphone = new Product
    {
      Name = "Smartphone",
      Description = "6.1-inch display",
      Price = new Price(699m),
      AvailableItemsInStock = 50,
      Category = electronics
    };

    var laptop = new Product
    {
      Name = "Laptop",
      Description = "Lightweight, 16GB RAM",
      Price = new Price(1299m),
      AvailableItemsInStock = 25,
      Category = electronics
    };

    var novel = new Product
    {
      Name = "Novel",
      Description = "Bestselling fiction",
      Price = new Price(14.99m),
      AvailableItemsInStock = 100,
      Category = books
    };

    // Reviews (Created will be stamped by DbContext on save)
    var reviews = new List<ProductReview>
    {
      new() { Product = smartphone, Rating = 5, Comment = "Excellent phone!" },
      new() { Product = smartphone, Rating = 4, Comment = "Great value." },
      new() { Product = laptop,     Rating = 4, Comment = "Powerful and portable." },
      new() { Product = novel,      Rating = 5, Comment = "Loved it." }
    };

    dbContext.ProductCategories.AddRange(electronics, books, clothing);
    dbContext.Products.AddRange(smartphone, laptop, novel);
    dbContext.ProductReviews.AddRange(reviews);

    await dbContext.SaveChangesAsync();
  }
}
