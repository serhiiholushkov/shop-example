using shop.Core.Product;

namespace shop.Infrastructure.Data.Config;

public class ProductReviewConfiguration : IEntityTypeConfiguration<ProductReview>
{
  public void Configure(EntityTypeBuilder<ProductReview> builder)
  {
    // builder.ToTable("ProductReviews"); in case we want to specify table name, constant can be moved to DataSchemaConstants

    builder.HasKey(pr => pr.Id);

    builder.Property(pr => pr.Rating)
        .IsRequired();

    builder.Property(pr => pr.Comment)
        .HasMaxLength(DataSchemaConstants.DEFAULT_DESCRIPTION_LENGTH);

    builder.Property(pr => pr.Created)
        .IsRequired();

    builder.HasOne(pr => pr.Product)
        .WithMany(p => p.Reviews)
        .HasForeignKey(pr => pr.ProductId)
        .IsRequired();
  }
}
