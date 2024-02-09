namespace IbsRestApi.Entities.iMoneytor;

public partial class RoaSummary
{
    public int IdRoasummary { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal? Equity { get; set; }
    public decimal? MoneyMarket { get; set; }
    public decimal? TreasuryBill { get; set; }
    public decimal? Bonds { get; set; }
    public string? Narration { get; set; }
    
}
