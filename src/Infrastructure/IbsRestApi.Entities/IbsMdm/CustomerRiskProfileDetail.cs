namespace IbsRestApi.Entities.IbsMdm;

public partial class CustomerRiskProfileDetail
{
    public int IdCustomerRiskProfileDetail { get; set; }
    public int? IdCustomerRiskProfile { get; set; }
    public int? IdRiskCheck { get; set; }
    public bool? YesNo { get; set; }

    public virtual CustomerRiskProfile? IdCustomerRiskProfileNavigation { get; set; }
    public virtual RiskChekList? IdRiskCheckNavigation { get; set; }
}
