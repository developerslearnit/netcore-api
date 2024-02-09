namespace IbsRestApi.Entities.iMoneytor;

public partial class Bondrecon
{
    public string? BondParticulars { get; set; }
    public DateTime? IssueDate { get; set; }
    public DateTime? LastCouponPymtDateB4Purchase { get; set; }
    public DateTime? LastCouponPymtDateThisCouponPeriod { get; set; }
    public DateTime? AmortizationDate { get; set; }
    public DateTime? ValueDate { get; set; }
    public DateTime? MaturityDate { get; set; }
    public double? FaceValue { get; set; }
    public double? CostPurchasePrice { get; set; }
    public double? CouponRate { get; set; }
    public double? PremiumAccrCouponAsAtPurchaseDate { get; set; }
    public double? NoOfDays { get; set; }
    public double? AccrCoupon { get; set; }
    public string? Bondid { get; set; }
    public double? NetPremium { get; set; }
    public double? NoOfDaysToMaturity { get; set; }
    public double? DailyPremium { get; set; }
    public string? NoOfDaysValueDateToDec312010 { get; set; }
    public string? AmountAmortizedUpToDec312010 { get; set; }
    public string? UnamortizedPremium { get; set; }
    public string? F21 { get; set; }
    public double? NoOfDaysThisCouponPeriod { get; set; }
    public double? AccruedInterestThisCouponPeriod { get; set; }
    public string? CurrentValue { get; set; }
}
