namespace IbsRestApi.Entities.iMoneytor;

public partial class ComplianceOverrideDetail
{
    public int IdComplianceOverrideDetails { get; set; }
    public int? IdComplianceOverrideMaster { get; set; }
    public string? IdComplianceBreakCode { get; set; }
    public string? IdInvestmentType { get; set; }
    public string? BreakNotes { get; set; }
    
}
