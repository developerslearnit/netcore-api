namespace IbsRestApi.Entities.iMoneytor;

public partial class ReportBatchMaster
{
    public int IdReportBatchMaster { get; set; }
    public string? BatchNo { get; set; }
    public string? Description { get; set; }
    public string? CreatedBy { get; set; }
    public string? SentBy { get; set; }
    public bool? Sent { get; set; }
}
