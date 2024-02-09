namespace IbsRestApi.Entities.iMoneytor;

public partial class EqStockAllocation
{
    public int IdStockAllocation { get; set; }
    public int? IdPortfolioGroup { get; set; }
    public int? ShareId { get; set; }
    public decimal? MaxPcent { get; set; }
    public int? IdEconomicSector { get; set; }
    
}
