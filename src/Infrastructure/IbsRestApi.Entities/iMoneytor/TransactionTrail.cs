namespace IbsRestApi.Entities.iMoneytor;

public partial class TransactionTrail
{
    public int IdTransactionTrail { get; set; }
    public int? IdPortfolio { get; set; }
    public string? IdInvestmentTypeName { get; set; }
    public string? IdInv { get; set; }
    public string? InvestmentModule { get; set; }
    public int? Id2link { get; set; }
    public string? Description { get; set; }
    public decimal? QtyUnits { get; set; }
    public decimal? TotalCost { get; set; }
    public decimal? Principal { get; set; }
    public decimal? FaceValue { get; set; }
    public decimal? PremiumDiscount { get; set; }
    public DateTime? ValueDate { get; set; }
    public int? Tenor { get; set; }
    public DateTime? MaturityDate { get; set; }
    public decimal? InterestRate { get; set; }
    public DateTime? IntBeginDate { get; set; }
    public DateTime? DisposalDate { get; set; }
    public int? Dats2CutOff { get; set; }
    public decimal? InterestIncome { get; set; }
    public decimal? CouponDifference { get; set; }
    public decimal? AmortiseDaily { get; set; }
    public int? AmortiseDays { get; set; }
    public decimal? AmortiseAmount { get; set; }
    public decimal? RealiseGainLoss { get; set; }
    public decimal? TotalIncome { get; set; }
    public decimal? MarketValue { get; set; }
}
