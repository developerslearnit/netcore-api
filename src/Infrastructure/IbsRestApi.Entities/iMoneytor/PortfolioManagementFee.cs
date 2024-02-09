namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioManagementFee
{
    public int IdPortfolioManagementFees { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? TransactionDate { get; set; }
    public DateTime? ValueDate { get; set; }
    public string? Narration { get; set; }
    public decimal? NetAssetValue { get; set; }
    public decimal? Amount { get; set; }
    public string? IdCurrency { get; set; }
    public decimal? CurExRate { get; set; }
    public string? VoucherNo { get; set; }
    public int? IdPortfolioInvoice { get; set; }
    public decimal? RebateAmount { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlPostPeriod { get; set; }
    public decimal? VatAmount { get; set; }
    public decimal? AssetMgrAmount { get; set; }
    public decimal? CustodianAmount { get; set; }
    public decimal? RegulatorAmount { get; set; }
    public decimal? DailyIncome { get; set; }
    public decimal? VatAmountCustodian { get; set; }
    public decimal? VatAmountRegulator { get; set; }
    public decimal? VatAmountAssetMgr { get; set; }
    
    public decimal? MtmMgtFees { get; set; }
    public decimal? MtmPfafees { get; set; }
    public decimal? MtmPfcfees { get; set; }
    public decimal? MtmRegfees { get; set; }

    public virtual Portfolio? IdPortfolioNavigation { get; set; }
}
