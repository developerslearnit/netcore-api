namespace IbsRestApi.Entities.iMoneytor;

public partial class EqDep
{
    public int DepositId { get; set; }
    public string? InvestType { get; set; }
    public int? ShareId { get; set; }
    public int? RightId { get; set; }
    public string? IssueId { get; set; }
    public string? Narration { get; set; }
    public decimal? QtyExpected { get; set; }
    public decimal? UnitCost { get; set; }
    public decimal? DepositAmount { get; set; }
    public string? BrokerId { get; set; }
    public DateTime? DepositDate { get; set; }
    public decimal? QtyAllotted { get; set; }
    public decimal? QtyRefunded { get; set; }
    public decimal? AmountRefunded { get; set; }
    public decimal? TotalInterest { get; set; }
    public int? BankId { get; set; }
    public string? Sign1Id { get; set; }
    public string? Sign2Id { get; set; }
    public string? ChequeNo { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public int? ReversalId { get; set; }
    public string? TransType { get; set; }
    public DateTime? SettlementDate { get; set; }
    public decimal? OtherCost { get; set; }
    public string? CapturedBy { get; set; }
    public string? ReviewedBy { get; set; }
    public string? ApprovedBy { get; set; }
    public string? VoucherNo { get; set; }
    public int? IdEquityMandateMaster { get; set; }
    
}
