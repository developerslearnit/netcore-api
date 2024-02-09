namespace IbsRestApi.Entities.iMoneytor;

public partial class ValuationHistorySave
{
    public int IdValuation { get; set; }
    public int? IdPortfolio { get; set; }
    public string? IdInvestmentType { get; set; }
    public int? Id2link { get; set; }
    public DateTime? ValuationDate { get; set; }
    public decimal? Qty { get; set; }
    public decimal? CurMrkPrice { get; set; }
    public decimal? AssetValue { get; set; }
    public decimal? GainLoss { get; set; }
    public string? VoucherNo { get; set; }
    public string? IdInv { get; set; }
    public decimal? TransactionCost { get; set; }
    public string? InvestmentModule { get; set; }
    public decimal? ExpectedDividend { get; set; }
    public decimal? StampDuty { get; set; }
    public decimal? Commission { get; set; }
    public decimal? Vat { get; set; }
    public decimal? SecFees { get; set; }
    public decimal? NseCscsfees { get; set; }
    public decimal? OtherFees { get; set; }
    public decimal? CostOfAsset { get; set; }
    public decimal? ExpectedBonus { get; set; }
    public decimal? WithholdingTax { get; set; }
    public int? IdCustomer { get; set; }
    public decimal? Interest2Date { get; set; }
    public decimal? MtmValue { get; set; }
    public decimal? MtmGainLoss { get; set; }
    public decimal? DayInterest { get; set; }
    public int? NoOfDays { get; set; }
    public decimal? DayPremiumDiscount { get; set; }
    public decimal? DayUnrealiseGainLoss { get; set; }
    public decimal? DayExchangeGainLoss { get; set; }
    public decimal? PremiumDiscount2Date { get; set; }
}
