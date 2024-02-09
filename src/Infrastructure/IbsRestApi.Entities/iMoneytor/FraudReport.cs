namespace IbsRestApi.Entities.iMoneytor;

public partial class FraudReport
{
    public int Sncode { get; set; }
    public string? PfaCode { get; set; }
    public string? PfaName { get; set; }
    public string? FraudCode { get; set; }
    public DateTime? DateCommitted { get; set; }
    public double? Amount { get; set; }
    public string? FraudStatus { get; set; }
    public double? ActualLoss { get; set; }
    public string? Description { get; set; }
    public string? ActionTaken { get; set; }
    public DateTime? ActionDate { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? StaffCode { get; set; }
    public string? Category { get; set; }
    public string? Nationality { get; set; }
    public string? PassportNo { get; set; }
    public string? Sex { get; set; }
    public string? Address { get; set; }
    public DateTime? Dob { get; set; }
    public string? StateCode { get; set; }
    
}
