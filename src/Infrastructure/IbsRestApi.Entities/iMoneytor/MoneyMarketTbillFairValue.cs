namespace IbsRestApi.Entities.iMoneytor;

public partial class MoneyMarketTbillFairValue
{
    public int IdTbillFairValue { get; set; }
    public int? IdDealMaster { get; set; }
    public DateTime? ValuationDate { get; set; }
    public decimal? AssetValue { get; set; }
    public decimal? Mtmvalue { get; set; }
    public decimal? GainLoss { get; set; }
    public string? VoucherNo { get; set; }
    public bool? Reversed { get; set; }
    public decimal? AnnualEir { get; set; }
    public decimal? DiscountFactor { get; set; }
    public decimal? AmortisedCost { get; set; }
    public decimal? YieldRate { get; set; }
    public decimal? Mtm2value { get; set; }
    public string? IdTreatmentType { get; set; }
    public decimal? MtmCost { get; set; }
}
