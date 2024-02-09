namespace IbsRestApi.Entities.iMoneytor;

public partial class TmpLnMast
{
    public int LoanId { get; set; }
    public string? InvestType { get; set; }
    public int? LoanTypeId { get; set; }
    public int? CustomerId { get; set; }
    public string? BrokerId { get; set; }
    public string? Narration { get; set; }
    public byte? Qouted { get; set; }
    public string? CurrencyId { get; set; }
    public decimal? UnitCost { get; set; }
    public int? QtyUnit { get; set; }
    public decimal? NorminalCost { get; set; }
    public string? IssueType { get; set; }
    public decimal? IssueRate { get; set; }
    public decimal? AcrBf { get; set; }
    public string? TransferNo { get; set; }
    public string? ContractNoteNo { get; set; }
    public decimal? StampDuty { get; set; }
    public decimal? Commission { get; set; }
    public decimal? Vat { get; set; }
    public decimal? SecFees { get; set; }
    public decimal? NseCscsfees { get; set; }
    public decimal? OtherFees { get; set; }
    public decimal? Premuim { get; set; }
    public decimal? Discount { get; set; }
    public decimal? TransactionCost { get; set; }
    public decimal? CostPrice { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public short? Moratoriunm { get; set; }
    public short? Tenor { get; set; }
    public DateTime? MaturityDate { get; set; }
    public int? BankId { get; set; }
    public string? ChequeNo { get; set; }
    public byte? ApplyWitholdingTax { get; set; }
    public decimal? QtyRedeemed { get; set; }
    public decimal? PrnRepaid { get; set; }
    public decimal? IntRepaid { get; set; }
    public DateTime? LastTransDate { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public string? IdBranch { get; set; }
    public string? IdProductLine { get; set; }
    public string? IdLocation { get; set; }
    public decimal? CumInterest { get; set; }
    public int? IdTransactionProcess { get; set; }
    public string? StockExchangeId { get; set; }
    public string? Symbol { get; set; }
    public DateTime? SettlementDate { get; set; }
}
