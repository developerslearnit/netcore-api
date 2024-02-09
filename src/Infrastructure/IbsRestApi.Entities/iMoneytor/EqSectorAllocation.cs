namespace IbsRestApi.Entities.iMoneytor;

public partial class EqSectorAllocation
{
    public int IdSectorAllocation { get; set; }
    public int? IdPortfolioGroup { get; set; }
    public int? IdEconomicSector { get; set; }
    public decimal? MaxPcent { get; set; }
    
}
