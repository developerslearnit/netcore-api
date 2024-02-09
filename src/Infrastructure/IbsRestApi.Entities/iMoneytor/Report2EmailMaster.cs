namespace IbsRestApi.Entities.iMoneytor;

public partial class Report2EmailMaster
{
    public int IdReport2EmailMaster { get; set; }
    public int? ReportId { get; set; }
    public int? ParamentersCount { get; set; }
    public string? MailBody { get; set; }
    public string? MailSubject { get; set; }
    
}
