namespace IbsRestApi.Entities.iMoneytor;

public partial class MoneyMaster
{
    public int IdMoneyMaster { get; set; }
    public short DrCr { get; set; }
    public string IdApplication { get; set; } = null!;
    public int? IdRequisitionMaster { get; set; }
    public int? IdReceiptMaster { get; set; }
    public string? PayeePayer { get; set; }
    public string? Beneficiary { get; set; }
    public string? IdBankAccount { get; set; }
    public decimal? ExRate { get; set; }
    public decimal? ForexAmount { get; set; }
    public decimal? ChqAmount { get; set; }
    public string? ChequeNo { get; set; }
    public DateTime? ChequeDate { get; set; }
    public string? Status { get; set; }
    public DateTime? StatusDate { get; set; }
    public byte? Collected { get; set; }
    public DateTime? DateCollected { get; set; }
    public DateTime? TransactionDate { get; set; }
    public byte? Cleared { get; set; }
    public byte? Reversed { get; set; }
    public int? ReversalId { get; set; }
    public string? Notes { get; set; }
    public byte? PrintCopy { get; set; }
    public int? IdConfirmation { get; set; }
    public byte? ChqCancelled { get; set; }
    public DateTime? ValueDate { get; set; }
    public bool? Posted { get; set; }
    public string? SourceBankId { get; set; }
    public string? SourceLocation { get; set; }
    public string? IdProductLine { get; set; }
    public string? RequestType { get; set; }
    public DateTime StatementDate { get; set; }
    public string? ReceiptType { get; set; }
    public string? VoucherNo { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlpostPeriod { get; set; }
    public int? Sign1Id { get; set; }
    public int? Sign2Id { get; set; }
    public int? IdMatchMaster { get; set; }
    public long? IdBankStatement { get; set; }
    public int? IdManyToMany { get; set; }
    public bool? OpenCheque { get; set; }
    public string? VjNumber { get; set; }
    public int? IdGlentry { get; set; }
    public long? Utid { get; set; }
    public int? IdEftdetails { get; set; }
    public string? SecurityNo { get; set; }
    public string? MatchedBy { get; set; }
    public string? UnMatchedBy { get; set; }
    public string? ReconComments { get; set; }
    public decimal? Amount { get; set; }
    public string? Being { get; set; }
}
