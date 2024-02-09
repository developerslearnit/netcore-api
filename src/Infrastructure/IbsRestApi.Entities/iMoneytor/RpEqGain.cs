namespace IbsRestApi.Entities.iMoneytor;

public partial class RpEqGain
{
    public int RpEqGain1 { get; set; }
    public int? ShareId { get; set; }
    public int? SectorId { get; set; }
    public int? TotShares { get; set; }
    public decimal? AvCost { get; set; }
    public decimal? Offer1Price { get; set; }
    public decimal? Gain1Loss { get; set; }
    public decimal? Un1Realised { get; set; }
    public decimal? Offer2Price { get; set; }
    public decimal? Gain2Loss { get; set; }
    public decimal? Un2Realised { get; set; }
    public decimal? PeriodGainLoss { get; set; }
    public decimal? TotalCost { get; set; }
    public decimal? MarketValue { get; set; }
    public decimal? Av1Cost { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal? TotShares1 { get; set; }
    public int? IdPortfolio { get; set; }
}
