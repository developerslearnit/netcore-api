namespace IbsRestApi.Entities.Secure;

public partial class SignatoryWorkFlow
{
    public int IdSignatoryWorkFlow { get; set; }
    public decimal? FromAmount { get; set; }
    public decimal? ToAmount { get; set; }
    public string? IdSignatory1Class { get; set; }
    public string? IdSignatory2Class { get; set; }
    public string? InvestmentRange { get; set; }

    public virtual SignatoryClass? IdSignatory1ClassNavigation { get; set; }
    public virtual SignatoryClass? IdSignatory2ClassNavigation { get; set; }
}
