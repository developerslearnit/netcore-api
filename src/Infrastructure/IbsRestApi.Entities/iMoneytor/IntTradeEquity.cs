namespace IbsRestApi.Entities.iMoneytor;

public partial class IntTradeEquity
{
    public int IdIntTradeEquity { get; set; }
    public DateTime? EntryDate { get; set; }
    public DateTime? TradeDate { get; set; }
    public DateTime? SettlementDate { get; set; }
    public string? TransactionCode { get; set; }
    public string? InvestmentIdentifier { get; set; }
    public string? InvestmentCurrency { get; set; }
    public string? Source { get; set; }
    public long? Quantity { get; set; }
    public decimal? Price { get; set; }
    public decimal? Commission { get; set; }
    public decimal? ExchangeFeesTaxes { get; set; }
    public decimal? ProceedsCost { get; set; }
    public decimal? AccruedInterest { get; set; }
    public decimal? NetMoney { get; set; }
    public string? SettlementCurrency { get; set; }
    public string? ExecutingBroker { get; set; }
    public string? DtceuroClear { get; set; }
    public string? ClearingPrimeBroker { get; set; }
    public string? InvestmentDescription { get; set; }
    public string? Strategy { get; set; }
    public bool? CommissionType { get; set; }
    public string? SecurityType { get; set; }
    public string? TradeType { get; set; }
    public string? SpecialInstructions { get; set; }
    public string? TraderName { get; set; }
    public string? InternalTradeReferenceNo { get; set; }
    public string? Book { get; set; }
    public decimal? ClearingFees { get; set; }
    public decimal? ImpliedRepoRate { get; set; }
    public decimal? OriginalFaceAmount { get; set; }
    public string? LegalEntity { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    
}
