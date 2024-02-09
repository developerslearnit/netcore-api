namespace IbsRestApi.Entities.IbsMdm;

public partial class SignatoryWorkFlowOld
{
    public int IdSignatoryWorkFlow { get; set; }
    public decimal? FromAmount { get; set; }
    public decimal? ToAmount { get; set; }
    public string? IdSignatory1Class { get; set; }
    public string? IdSignatory2Class { get; set; }
    public string? InvestmentRange { get; set; }

    public virtual SignatoryClassOld? IdSignatory1ClassNavigation { get; set; }
    public virtual SignatoryClassOld? IdSignatory2ClassNavigation { get; set; }
}
