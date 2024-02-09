namespace IbsRestApi.Entities.iMoneytor;

public partial class DismissalReport
{
    public int Sncode { get; set; }
    public string? PfaCode { get; set; }
    public string? PfaName { get; set; }
    public string? Surname { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? StaffCode { get; set; }
    public string? Designation { get; set; }
    public string? Address { get; set; }
    public DateTime? Dob { get; set; }
    public string? StateCode { get; set; }
    public string? Department { get; set; }
    public DateTime? DateTermination { get; set; }
    public string? DismissalReason { get; set; }
    public string? DismissalCode { get; set; }
    public string? FraudCode { get; set; }
    public string? ReIntstateReason { get; set; }
    
}
