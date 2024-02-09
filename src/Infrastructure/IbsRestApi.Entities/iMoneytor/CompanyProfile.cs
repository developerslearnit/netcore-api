namespace IbsRestApi.Entities.iMoneytor;

public partial class CompanyProfile
{
    public string PfaCode { get; set; } = null!;
    public string? PfaName { get; set; }
    public string? Address1 { get; set; }
    public string? City1 { get; set; }
    public string? State { get; set; }
    public string? StateCode { get; set; }
    public string? EMailAddy { get; set; }
    public string? PfaTel1 { get; set; }
    public string? PfaTel2 { get; set; }
    public string? PfaFax1 { get; set; }
    public string? PfaFax2 { get; set; }
    public string? LicNo { get; set; }
    public int? Shareholder { get; set; }
    public int? Directors { get; set; }
    public int? BranchesApproved { get; set; }
    public int? BranchesNotApproved { get; set; }
    public int? TotalBranches { get; set; }
    public int? TotalOrdShare { get; set; }
    public int? PrivateInv { get; set; }
    public int? ForeignInv { get; set; }
    public int? InstInv { get; set; }
    public DateTime? ComDate { get; set; }
    public int? YearEnd { get; set; }
    public int? NoOfAuditors { get; set; }
    public string? AuditFirm1 { get; set; }
    public int? AuditorsNo1 { get; set; }
    public string? AuditAddress1 { get; set; }
    public string? AuditCity1 { get; set; }
    public string? AuditState1 { get; set; }
    public string? AuditStateCode1 { get; set; }
    public string? AuditPhone1 { get; set; }
    public string? AuditFax1 { get; set; }
    public string? AuditFirm2 { get; set; }
    public int? AuditorsNo2 { get; set; }
    public string? AuditAddress2 { get; set; }
    public string? AuditCity2 { get; set; }
    public string? AuditState2 { get; set; }
    public string? AuditStateCode2 { get; set; }
    public string? AuditPhone2 { get; set; }
    public string? AuditFax2 { get; set; }
    
}
