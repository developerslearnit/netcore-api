namespace IbsRestApi.Entities.Secure;

public partial class SignatoryClass
{
    public SignatoryClass()
    {
        Signatories = new HashSet<Signatory>();
        SignatoryWorkFlowIdSignatory1ClassNavigations = new HashSet<SignatoryWorkFlow>();
        SignatoryWorkFlowIdSignatory2ClassNavigations = new HashSet<SignatoryWorkFlow>();
    }

    public string IdSignatoryClass { get; set; } = null!;
    public string? SignatoryClass1 { get; set; }

    public virtual ICollection<Signatory> Signatories { get; set; }
    public virtual ICollection<SignatoryWorkFlow> SignatoryWorkFlowIdSignatory1ClassNavigations { get; set; }
    public virtual ICollection<SignatoryWorkFlow> SignatoryWorkFlowIdSignatory2ClassNavigations { get; set; }
}
