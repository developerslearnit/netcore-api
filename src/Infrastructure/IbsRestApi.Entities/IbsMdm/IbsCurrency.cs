namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsCurrency
{
    public IbsCurrency()
    {
        IbsExcRates = new HashSet<IbsExcRate>();
    }

    public string IdCurrency { get; set; } = null!;
    public string? Currency { get; set; }
    public string? Unit { get; set; }

    public virtual ICollection<IbsExcRate> IbsExcRates { get; set; }
}
