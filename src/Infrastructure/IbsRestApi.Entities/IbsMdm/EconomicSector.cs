namespace IbsRestApi.Entities.IbsMdm;

public partial class EconomicSector
{
    public EconomicSector()
    {
        NatureOfbusinesses = new HashSet<NatureOfbusiness>();
    }

    public int IdEconomicSector { get; set; }
    public string? EconomicSector1 { get; set; }

    public virtual ICollection<NatureOfbusiness> NatureOfbusinesses { get; set; }
}
