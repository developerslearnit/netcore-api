namespace IbsRestApi.Entities.iMoneytor;

public partial class RatingEngine
{
    public int IdRatingEngine { get; set; }
    public string? Rating { get; set; }
    public decimal? EquityMaxRate { get; set; }
    public decimal? MoneyMarketMaxRate { get; set; }
    public decimal? BondsMaxRate { get; set; }
    public decimal? RealEstateMaxRate { get; set; }
    public string? ComplianceBasedOn { get; set; }
    
}
