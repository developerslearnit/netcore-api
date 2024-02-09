namespace IbsRestApi.Entities.iMoneytor;

public partial class ComplianceOverRideMaster
{
    public int IdComplianceOverRideMaster { get; set; }
    public string? InvestmentModule { get; set; }
    public DateTime? RequestDate { get; set; }
    public string? Narration { get; set; }
    public string? ViewFormName { get; set; }
    public string? SqlTableName { get; set; }
    public string? FieldName { get; set; }
    public int? FieldValue { get; set; }
    public string? RequestedBy { get; set; }
    public string? OverRideBy { get; set; }
    public DateTime? OverRideDate { get; set; }
    public string? OverriderComments { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    
}
