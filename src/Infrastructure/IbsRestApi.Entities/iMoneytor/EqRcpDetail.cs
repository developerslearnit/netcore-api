namespace IbsRestApi.Entities.iMoneytor;

public partial class EqRcpDetail
{
    public int IdEqRcpDetails { get; set; }
    public int? IdEqRcpMaster { get; set; }
    public int? IdPortfolio { get; set; }
    public decimal? QtyUnit { get; set; }
    public decimal? UnitCost { get; set; }
    public decimal? Cscsqty { get; set; }
    public decimal? CerificateQty { get; set; }
    public decimal? AllocatedCost { get; set; }
    public decimal? QtySold { get; set; }
    public decimal? CostOfSales { get; set; }
    public decimal? SalesProceed { get; set; }
    public decimal? MarketValue { get; set; }
    public string? SalesType { get; set; }
    public decimal? ComChgAmount { get; set; }
    
}
