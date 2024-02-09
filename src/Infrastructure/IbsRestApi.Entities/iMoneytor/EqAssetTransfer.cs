namespace IbsRestApi.Entities.iMoneytor;

public partial class EqAssetTransfer
{
    public int IdEqAssetTransfer { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? TransferDate { get; set; }
    public string? Narration { get; set; }
    public decimal? AssetValue { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public string? BrokerId { get; set; }
    public string? TransactionChargesType { get; set; }
    public decimal? SellComRate { get; set; }
    public decimal? BuyComRate { get; set; }
    public decimal? TotalCharges { get; set; }
    public byte? Cscstransaction { get; set; }
    public string? Cscsid { get; set; }
    public string? InvestorAccountNo { get; set; }
    public string? VoucherNo { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlPostPeriod { get; set; }
    
}
