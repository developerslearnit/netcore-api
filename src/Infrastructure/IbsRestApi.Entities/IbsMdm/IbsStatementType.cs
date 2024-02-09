namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsStatementType
{
    public string IdStatementType { get; set; } = null!;
    public string? StatementType { get; set; }
    public int? ReportId { get; set; }
    public decimal? Fees { get; set; }
    public bool? DateRangeRequired { get; set; }
    public string? CrystalReportFileName { get; set; }
}
