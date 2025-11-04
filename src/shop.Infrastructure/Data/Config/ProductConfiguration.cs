using shop.Core.Product;

namespace shop.Infrastructure.Data.Config;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
  public void Configure(EntityTypeBuilder<Product> builder)
  {
    // builder.ToTable("Products"); in case we want to specify table name, constant can be moved to DataSchemaConstants

    builder.HasKey(p => p.Id);

    builder.Property(p => p.Name)
        .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
        .IsRequired();

    builder.Property(p => p.Description)
        .HasMaxLength(DataSchemaConstants.DEFAULT_DESCRIPTION_LENGTH);

    builder.OwnsOne(p => p.Price, priceBuilder =>
    {
      priceBuilder.Property(p => p.Amount)
          .HasPrecision(18, 2)
          .IsRequired();

      priceBuilder.Property(p => p.Currency)
          .HasMaxLength(3)
          .IsRequired();
    });

    builder.HasOne(p => p.Category)
        .WithMany(pc => pc.Products)
        .HasForeignKey(p => p.CategoryId)
        .IsRequired();
  }
}
