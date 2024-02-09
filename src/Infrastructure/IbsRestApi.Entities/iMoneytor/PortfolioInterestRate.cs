namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioInterestRate
{
    public int IdPortfolioIntRate { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? EffeciveDate { get; set; }
    public string? RateType { get; set; }
    public decimal? InterestRate { get; set; }
    
}
