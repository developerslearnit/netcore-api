namespace IbsRestApi.Entities.IbsMdm;

public partial class NatureOfbusiness
{
    public int IdNatureOfbusiness { get; set; }
    public int? IdEconomicSector { get; set; }
    public string? NatureOfbusiness1 { get; set; }

    public virtual EconomicSector? IdEconomicSectorNavigation { get; set; }
}
