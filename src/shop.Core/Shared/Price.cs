namespace shop.Core.Shared;

public record Price
{
  public decimal Amount { get; init; }
  public string Currency { get; init; }

  public Price(decimal aamount = 0, string currency = Currencies.USD)
  {
    this.Amount = aamount;
    this.Currency = currency;
  }
}
