namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsState
{
    public IbsState()
    {
        IbsLgareas = new HashSet<IbsLgarea>();
    }

    public string IdState { get; set; } = null!;
    public string? Title { get; set; }
    public string? IdCountry { get; set; }

    public virtual ICollection<IbsLgarea> IbsLgareas { get; set; }
}
