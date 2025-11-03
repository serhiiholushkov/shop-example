using shop.Core.ContributorAggregate;
using shop.Core.Product;
using shop.Infrastructure.Data.Converters;

namespace shop.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options,
  IDomainEventDispatcher? dispatcher) : DbContext(options)
{
  private readonly IDomainEventDispatcher? _dispatcher = dispatcher;

  public DbSet<Contributor> Contributors => Set<Contributor>();

  public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();
  public DbSet<Product> Products => Set<Product>();
  public DbSet<ProductReview> ProductReviews => Set<ProductReview>();

  protected override void ConfigureConventions(ModelConfigurationBuilder builder)
  {
    builder.Properties<DateTime>().HaveConversion<DateTimeUtcConverter>();
    builder.Properties<DateTime?>().HaveConversion<NullableDateTimeUtcConverter>();
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    StampAuditTimestamps();

    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    // ignore events if no dispatcher provided
    if (_dispatcher == null) return result;

    // dispatch events only if save was successful
    var entitiesWithEvents = ChangeTracker.Entries<HasDomainEventsBase>()
        .Select(e => e.Entity)
        .Where(e => e.DomainEvents.Any())
        .ToArray();

    await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

    return result;
  }

  public override int SaveChanges() =>
        SaveChangesAsync().GetAwaiter().GetResult();

  /// <summary>
  /// Sets Created and Updated timestamps on entities that have those properties.
  /// </summary>
  private void StampAuditTimestamps()
  {
    var now = DateTime.UtcNow;

    foreach (var entry in ChangeTracker.Entries())
    {
      if (entry.State == EntityState.Added)
      {
        if (entry.Metadata.FindProperty("Created") is not null)
        {
          var created = entry.Property("Created");
          if (created.CurrentValue is null ||
              (created.CurrentValue is DateTime dt && dt == default))
          {
            created.CurrentValue = now;
          }
        }

        if (entry.Metadata.FindProperty("Updated") is not null)
        {
          entry.Property("Updated").CurrentValue = null;
        }
      }
      else if (entry.State == EntityState.Modified)
      {
        if (entry.Metadata.FindProperty("Created") is not null)
        {
          // prevent overwriting Created on updates
          entry.Property("Created").IsModified = false;
        }

        if (entry.Metadata.FindProperty("Updated") is not null)
        {
          entry.Property("Updated").CurrentValue = now;
        }
      }
    }
  }
}
