namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioDirectGlposting
{
    public int IdPortfolioDirectGlposting { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? TransactionDate { get; set; }
    public DateTime? ValueDate { get; set; }
    public string? Narration { get; set; }
    public decimal? Amount { get; set; }
    public string? DrActNo { get; set; }
    public string? CrActNo { get; set; }
    public string? CapturedBy { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? Approveddate { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public string? TransactionType { get; set; }
    public string? VoucherNo { get; set; }
    public string? TransactionClass { get; set; }
    
}
