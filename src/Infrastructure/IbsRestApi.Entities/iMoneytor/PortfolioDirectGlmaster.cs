namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioDirectGlmaster
{
    public int IdPortfolioDirectGlmaster { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? TransactionDate { get; set; }
    public DateTime? ValueDate { get; set; }
    public string? Narration { get; set; }
    public decimal? DrAmount { get; set; }
    public decimal? CrAmount { get; set; }
    public string? CapturedBy { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovedDate { get; set; }
    public string? VoucherNo { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public string? IdCurrency { get; set; }
    public string? DocumentHyperLink { get; set; }
    
    public bool? DoNotExportToExternalGl { get; set; }
}
