namespace IbsRestApi.Entities.IbsMdm;

public partial class RiskChekList
{
    public RiskChekList()
    {
        CustomerRiskProfileDetails = new HashSet<CustomerRiskProfileDetail>();
    }

    public int IdRiskCheck { get; set; }
    public string? RiskDescription { get; set; }
    public string? RiskClass { get; set; }

    public virtual ICollection<CustomerRiskProfileDetail> CustomerRiskProfileDetails { get; set; }
}
