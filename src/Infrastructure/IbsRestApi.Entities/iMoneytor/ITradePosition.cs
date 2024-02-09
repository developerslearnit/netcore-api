namespace IbsRestApi.Entities.iMoneytor;

public partial class ITradePosition
{
    public int IdTradePosition { get; set; }
    public int? ShareId { get; set; }
    public int? IdDealMaster { get; set; }
    public int? IdLoanMaster { get; set; }
    public string? SfkaccountCode { get; set; }
    public string? SecurityCode { get; set; }
    public string? LocationCode { get; set; }
    public string? Isincode { get; set; }
    public DateTime? HoldingDate { get; set; }
    public decimal? SecurityPrice { get; set; }
    public int? Quantity { get; set; }
    public decimal? BookCost { get; set; }
    public decimal? MarketValue { get; set; }
    public string? Status { get; set; }
    public DateTime? TransactionDate { get; set; }
    
}
