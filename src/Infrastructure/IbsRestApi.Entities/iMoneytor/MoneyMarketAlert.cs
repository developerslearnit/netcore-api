namespace IbsRestApi.Entities.iMoneytor;

public partial class MoneyMarketAlert
{
    public long IdMoneyMarketAlert { get; set; }
    public DateTime MaturityDate { get; set; }
    public double TargetRate { get; set; }
    public int TargetType { get; set; }
    public double RateChange { get; set; }
    public int RateChangeType { get; set; }
    public string Type { get; set; } = null!;
    public DateTime DateCreated { get; set; }
    public bool IsTriggered { get; set; }
    public DateTime? DateTriggered { get; set; }
    public string? UserName { get; set; }
}
