namespace IbsRestApi.Entities.iMoneytor;

public partial class EqTraAll
{
    public int EquityAllocationId { get; set; }
    public int? UniqueId { get; set; }
    public int? ShareId { get; set; }
    public int? PortfolioId { get; set; }
    public int? PortfolioGroupId { get; set; }
    public string? IssueId { get; set; }
    public DateTime? IssueDate { get; set; }
    public DateTime? LodgementDate { get; set; }
    public string? CrDr { get; set; }
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
    public string? Cscsid { get; set; }
    public string? InvestorAccountNo { get; set; }
    public DateTime? LastValuationDate { get; set; }
    public decimal? NetAssetValue { get; set; }
    public decimal? LastMarketPrice { get; set; }
    public int? MatchId { get; set; }
    public decimal? BookCost { get; set; }
    public int? IdSellTriger { get; set; }
    
    public decimal? UnRealisedGainLoss { get; set; }
}
