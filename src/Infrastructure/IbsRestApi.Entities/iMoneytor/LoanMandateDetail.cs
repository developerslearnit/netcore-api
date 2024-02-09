namespace IbsRestApi.Entities.iMoneytor;

public partial class LoanMandateDetail
{
    public int IdLoanMandateDetails { get; set; }
    public int? IdLoanMandateMaster { get; set; }
    public int? IdPortfolio { get; set; }
    public string? Symbol { get; set; }
    public string? IssueType { get; set; }
    public decimal? QtyUnits { get; set; }
    public decimal? NorminalValue { get; set; }
    public decimal? CleanPrice { get; set; }
    public DateTime? EntryDate { get; set; }
    public DateTime? SettlementDate { get; set; }
    public decimal? YieldToMaturity { get; set; }
    public decimal? PurchaseCoupon { get; set; }
    public decimal? Consideration { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public decimal? ParValue { get; set; }
    public int? DaysBf { get; set; }
    public int? QtyOwned { get; set; }
    public int? LoanId { get; set; }
    public int? LoanQtyBalance { get; set; }
    public decimal? PremiumDiscount { get; set; }
    public int? IdIvcmandateDetails { get; set; }
    public DateTime? LastCouponDate { get; set; }
    public string? IntCalcMethod { get; set; }
    public string? BuyerName { get; set; }
    public string? SellerName { get; set; }
    public decimal? ManualPurchaseCoupon { get; set; }
    public decimal? PurCouponAdjustment { get; set; }
    public string? IdTreatmentType { get; set; }
    public string? Cscsid { get; set; }
    public string? ReferenceNo { get; set; }
    public string? InvestorActNo { get; set; }
    public bool? OverRideCouponBf { get; set; }
    public int? IdSettlementModes { get; set; }
    public int? IdPortfolioCustodian { get; set; }
    public string? IdBankAccount { get; set; }
    public decimal? ExRate { get; set; }
}
