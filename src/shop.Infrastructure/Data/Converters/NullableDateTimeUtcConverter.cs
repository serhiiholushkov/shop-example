using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
namespace shop.Infrastructure.Data.Converters;

public class NullableDateTimeUtcConverter : ValueConverter<DateTime?, DateTime?>
{
  public NullableDateTimeUtcConverter() : base(
    v => v.HasValue ? (v.Value.Kind == DateTimeKind.Utc ? v.Value : v.Value.ToUniversalTime()) : v,
    v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v)
  { }
}
