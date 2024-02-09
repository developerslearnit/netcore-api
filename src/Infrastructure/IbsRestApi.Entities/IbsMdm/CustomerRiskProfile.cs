namespace IbsRestApi.Entities.IbsMdm;

public partial class CustomerRiskProfile
{
    public CustomerRiskProfile()
    {
        CustomerRiskProfileDetails = new HashSet<CustomerRiskProfileDetail>();
    }

    public int IdCustomerRiskProfile { get; set; }
    public int? Ucid { get; set; }
    public string? Referee { get; set; }
    public string? AssessesBy { get; set; }
    public DateTime? ProcessDate { get; set; }
    public string? CapturedBy { get; set; }
    public DateTime? CapturedDate { get; set; }
    public string? Status { get; set; }
    public string? RiskClass { get; set; }

    public virtual IbsPerson? Uc { get; set; }
    public virtual ICollection<CustomerRiskProfileDetail> CustomerRiskProfileDetails { get; set; }
}
