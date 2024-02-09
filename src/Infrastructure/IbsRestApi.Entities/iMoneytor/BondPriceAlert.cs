namespace IbsRestApi.Entities.iMoneytor;

public partial class BondPriceAlert
{
    public long IdBondPriceAlert { get; set; }
    public string Symbol { get; set; } = null!;
    public double TargetPrice { get; set; }
    public int TargetType { get; set; }
    public double PriceChange { get; set; }
    public int PriceChangeType { get; set; }
    public string Type { get; set; } = null!;
    public DateTime DateCreated { get; set; }
    public bool IsTriggered { get; set; }
    public DateTime? DateTriggered { get; set; }
    public string? UserName { get; set; }
}
