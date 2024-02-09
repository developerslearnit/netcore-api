namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioDrCrInvoice
{
    public int IdPortfolioDrCrInvoice { get; set; }
    public int? IdPortfolioDrCrMaster { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? TransactionDate { get; set; }
    public DateTime? InvoiceDate { get; set; }
    public decimal? Amount { get; set; }
    public string? Narration { get; set; }
    public string? CapturedBy { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public string? VoucherNo { get; set; }
    public DateTime? GlpostDate { get; set; }
    public DateTime? ApplyDate { get; set; }
    
}
