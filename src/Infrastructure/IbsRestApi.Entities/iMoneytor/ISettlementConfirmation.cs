namespace IbsRestApi.Entities.iMoneytor;

public partial class ISettlementConfirmation
{
    public int IdSettleConsfirmation { get; set; }
    public int? ShareId { get; set; }
    public int? IdDealMaster { get; set; }
    public int? IdLoanMaster { get; set; }
    public string? SfkaccountCode { get; set; }
    public string? TradeReference { get; set; }
    public string? TradeCode { get; set; }
    public string? LocationCode { get; set; }
    public string? BrokerCode { get; set; }
    public string? SecurityCode { get; set; }
    public string? Isincode { get; set; }
    public DateTime? TradeDate { get; set; }
    public DateTime? Csd { get; set; }
    public DateTime? Asd { get; set; }
    public int? Quantity { get; set; }
    public string? CurrencyCode { get; set; }
    public decimal? Price { get; set; }
    public decimal? ExchangeRate { get; set; }
    public decimal? InterestRate { get; set; }
    public decimal? GrossSettAmt { get; set; }
    public decimal? StampDuty { get; set; }
    public decimal? BrokerComm { get; set; }
    public decimal? Seccomm { get; set; }
    public decimal? Stxcomm { get; set; }
    public decimal? Cscscomm { get; set; }
    public decimal? Vat { get; set; }
    public decimal? NetSettAmt { get; set; }
    public decimal? OtherCharges { get; set; }
    public decimal? BookCost { get; set; }
    public string? Status { get; set; }
    public DateTime? TransactionDate { get; set; }
    public DateTime? MatchingDate { get; set; }
    
}
