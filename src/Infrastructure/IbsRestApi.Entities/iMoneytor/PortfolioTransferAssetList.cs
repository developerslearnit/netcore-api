namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioTransferAssetList
{
    public int IdPortfolioTransferAssetList { get; set; }
    public int? IdPortfolioTransfer { get; set; }
    public int? LoanId { get; set; }
    public int? IdDealMaster { get; set; }
    public int? ShareId { get; set; }
    public decimal? AssetValue { get; set; }
    public int? FromPortfolioId { get; set; }
    public int? ToPortfolioId { get; set; }
    public DateTime? TransferDate { get; set; }
    public string? VoucherNo { get; set; }
}
