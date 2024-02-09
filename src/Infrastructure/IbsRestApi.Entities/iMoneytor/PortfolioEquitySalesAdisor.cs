namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioEquitySalesAdisor
{
    public int IdEquitySalesTriger { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public string? Symbol { get; set; }
    public decimal? QtyOwned { get; set; }
    public decimal? CostPrice { get; set; }
    public decimal? ProfitTriger { get; set; }
    public decimal? LossTriger { get; set; }
    public decimal? Gain { get; set; }
    public decimal? Loss { get; set; }
    public string? Advise { get; set; }
    public int? IdSellTriger { get; set; }
    public int? ShareId { get; set; }
    public int? UniqueId { get; set; }
    public decimal? MarketPrice { get; set; }
    public decimal? MarketValue { get; set; }
    public DateTime? AlertDate { get; set; }
}
