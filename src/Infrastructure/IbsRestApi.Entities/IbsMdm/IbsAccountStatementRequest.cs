namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsAccountStatementRequest
{
    public int IdAccountStatementRequest { get; set; }
    public string? IdStatementType { get; set; }
    public DateTime? RequestDate { get; set; }
    public int? Ucid { get; set; }
    public int? IdPortfolioContributor { get; set; }
    public DateTime? CaptureDate { get; set; }
    public string? Capturedby { get; set; }
    public string? Printedby { get; set; }
    public DateTime? Printdate { get; set; }
    public decimal? Amount { get; set; }
    public bool? Posted { get; set; }
    public string? VoucherNo { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public string? PdfFileName { get; set; }
    public DateTime? SentDate { get; set; }
    public string? Sentby { get; set; }
    public int? Dbid { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? IdToPrint { get; set; }
}
