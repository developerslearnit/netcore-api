namespace IbsRestApi.Entities.iMoneytor;

public partial class EqRsaAll
{
    public int IdEqRsaAll { get; set; }
    public int ShareId { get; set; }
    public int? SaleId { get; set; }
    public int PortfolioId { get; set; }
    public int? RightQty { get; set; }
    public int? QtySold { get; set; }
    public decimal? SalesProceed { get; set; }
    public decimal? Commision { get; set; }
    public decimal? ProfitLoss { get; set; }
    
}
