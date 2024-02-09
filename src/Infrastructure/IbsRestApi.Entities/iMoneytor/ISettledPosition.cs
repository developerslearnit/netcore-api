namespace IbsRestApi.Entities.iMoneytor;

public partial class ISettledPosition
{
    public int IdSettledPosition { get; set; }
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
    public decimal? AccruedInterest { get; set; }
    public decimal? MarketValue { get; set; }
    public decimal? UnregisteredPosition { get; set; }
    public decimal? RegistrationPosition { get; set; }
    public string? Status { get; set; }
    
}
