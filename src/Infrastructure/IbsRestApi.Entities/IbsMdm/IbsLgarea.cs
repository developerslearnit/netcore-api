namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsLgarea
{
    public string IdLga { get; set; } = null!;
    public string IdState { get; set; } = null!;
    public string LgArea { get; set; } = null!;

    public virtual IbsState IdStateNavigation { get; set; } = null!;
}
