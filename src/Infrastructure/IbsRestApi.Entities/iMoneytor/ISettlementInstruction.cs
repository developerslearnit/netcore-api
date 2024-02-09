namespace IbsRestApi.Entities.iMoneytor;

public partial class ISettlementInstruction
{
    public int IdSettleInstuction { get; set; }
    public string? IdInvestmentType { get; set; }
    public string? Narration { get; set; }
    public int? ShareId { get; set; }
    public int? UniqueId { get; set; }
    public int? DepositId { get; set; }
    public int? RightId { get; set; }
    public int? IdDealMaster { get; set; }
    public int? IdLoanMaster { get; set; }
    public int? IdRealEstate { get; set; }
    public string? SfkaccountCode { get; set; }
    public string? TradeReference { get; set; }
    public string? TradeCode { get; set; }
    public string? BrokerCode { get; set; }
    public string? SecurityCode { get; set; }
    public string? Isincode { get; set; }
    public DateTime? TradeDate { get; set; }
    public DateTime? Csd { get; set; }
    public int? Quantity { get; set; }
    public decimal? Price { get; set; }
    public decimal? GrossSettAmt { get; set; }
    public decimal? StampDuty { get; set; }
    public decimal? BrokerComm { get; set; }
    public decimal? Seccomm { get; set; }
    public decimal? Stxcomm { get; set; }
    public decimal? Cscscomm { get; set; }
    public decimal? Vat { get; set; }
    public decimal? OtherCharges { get; set; }
    public decimal? NetSettAmt { get; set; }
    public DateTime? InstructionDate { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public int? CallBackId { get; set; }
    public string? TransType { get; set; }
    public DateTime? TransactionDate { get; set; }
    public DateTime? ConfirmationDate { get; set; }
    public DateTime? MatchingDate { get; set; }
    
}
