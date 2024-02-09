namespace IbsRestApi.Entities.IbsMdm;

public partial class SignatoryClassOld
{
    public SignatoryClassOld()
    {
        SignatoryOlds = new HashSet<SignatoryOld>();
        SignatoryWorkFlowOldIdSignatory1ClassNavigations = new HashSet<SignatoryWorkFlowOld>();
        SignatoryWorkFlowOldIdSignatory2ClassNavigations = new HashSet<SignatoryWorkFlowOld>();
    }

    public string IdSignatoryClass { get; set; } = null!;
    public string? SignatoryClass { get; set; }

    public virtual ICollection<SignatoryOld> SignatoryOlds { get; set; }
    public virtual ICollection<SignatoryWorkFlowOld> SignatoryWorkFlowOldIdSignatory1ClassNavigations { get; set; }
    public virtual ICollection<SignatoryWorkFlowOld> SignatoryWorkFlowOldIdSignatory2ClassNavigations { get; set; }
}
