namespace IbsRestApi.Entities.iMoneytor;

public partial class Report2EmailLog
{
    public int IdReport2EmailLog { get; set; }
    public int? ReportId { get; set; }
    public int? IdPortfoilio { get; set; }
    public DateTime? SentDate { get; set; }
    public string? SentBy { get; set; }
    
    public int? IdPortfolioContributor { get; set; }
    public string? PdfFileName { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public DateTime? CreationDate { get; set; }
    public bool? Resent { get; set; }
    public string? CreatedBy { get; set; }
    public string? Subject { get; set; }
    public bool? IsHtmlText { get; set; }
    public int? Ucid { get; set; }
    public string? BatchNo { get; set; }
}
