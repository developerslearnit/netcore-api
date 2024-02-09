namespace IbsRestApi.Entities.iMoneytor;

public partial class BorrowRequisition
{
    public int IdBorrowRequisition { get; set; }
    public int? IdBorrowMaster { get; set; }
    public DateTime? RequestDate { get; set; }
    public string? Payee { get; set; }
    public string? Being { get; set; }
    public string? RequestType { get; set; }
    public decimal? Amount { get; set; }
    public decimal? Commision { get; set; }
    public decimal? WithTaxAmount { get; set; }
    public string? Status { get; set; }
    public string? VoucherNo { get; set; }
    public int? ReversalId { get; set; }
    public string? BrokerId { get; set; }
    public DateTime? SettlementDate { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlPostPeriod { get; set; }
    public long? Utid { get; set; }
    public int? ExtraDays { get; set; }
    public decimal? Extrainterest { get; set; }
    public string? IdBankAccount { get; set; }
    public bool? PayExtraDays { get; set; }
    public string? Comments { get; set; }
    public bool? AutoPosted { get; set; }
    public string? IdBank { get; set; }
    public string? ApprovedBy { get; set; }
    public decimal? PrnAmount { get; set; }
    public decimal? IntAmount { get; set; }
    public string? CapturedBy { get; set; }
    public string? BankAccountNo { get; set; }
    public string? BankAccountName { get; set; }
    public bool? UpFrontRequest { get; set; }
}
