using shop.Core.Product;

namespace shop.Infrastructure.Data.Config;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
  public void Configure(EntityTypeBuilder<ProductCategory> builder)
  {
    // builder.ToTable("ProductCategories"); in case we want to specify table name, constant can be moved to DataSchemaConstants

    builder.HasKey(pc => pc.Id);

    builder.Property(pc => pc.Name)
        .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
        .IsRequired();

    builder.Property(pc => pc.Description)
        .HasMaxLength(DataSchemaConstants.DEFAULT_DESCRIPTION_LENGTH);
  }
}
