namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioInvoice
{
    public int IdPortfolioInvoice { get; set; }
    public int? IdPortfolio { get; set; }
    public string? InvoiceNo { get; set; }
    public DateTime? InvoiceDate { get; set; }
    public decimal? Amount { get; set; }
    public string? Narration { get; set; }
    public decimal? Due2Pfa { get; set; }
    public decimal? Due2Pfc { get; set; }
    public decimal? Due2PenCom { get; set; }
    public string? CapturedBy { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public string? VoucherNo { get; set; }
    public DateTime? ApplyDate { get; set; }
    public DateTime? TransactionDate { get; set; }
    public decimal? IncentiveDue { get; set; }
    public decimal? VatAmount { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlPostPeriod { get; set; }
    
}
