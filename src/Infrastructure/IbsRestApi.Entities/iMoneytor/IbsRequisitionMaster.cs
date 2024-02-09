namespace IbsRestApi.Entities.iMoneytor;

public partial class IbsRequisitionMaster
{
    public int IdRequisitionMaster { get; set; }
    public string? IdApplication { get; set; }
    public DateTime? ChequeRequestDate { get; set; }
    public string? RequestType { get; set; }
    public string Payee { get; set; } = null!;
    public string Beneficiary { get; set; } = null!;
    public decimal? ExRate { get; set; }
    public decimal? ForexAmount { get; set; }
    public decimal? AmountRequested { get; set; }
    public DateTime? ChequeValueDate { get; set; }
    public string? RequesterName { get; set; }
    public string? ProcessedBy { get; set; }
    public string? FinalApprovalBy { get; set; }
    public DateTime? FinallDate { get; set; }
    public string Status { get; set; } = null!;
    public DateTime? StatusDate { get; set; }
    public DateTime? TransactionDate { get; set; }
    public string? Notes { get; set; }
    public string? IdBankAccount { get; set; }
    public string? CheqNo { get; set; }
    public int? Sign1Id { get; set; }
    public int? Sign2Id { get; set; }
    public byte? PrintCopy { get; set; }
    public bool? ForexBased { get; set; }
    public string? VoucherNo { get; set; }
    public string? Send2ApplicationId { get; set; }
    public string? TransferStatus { get; set; }
    public bool? Merged { get; set; }
    public string? LetterText { get; set; }
    public int? MergeIdIbsRequisitionMaster { get; set; }
    public int? IdReceiptMaster { get; set; }
    public string? CustomerCode { get; set; }
    public string? ScanDocFileName { get; set; }
    public decimal? VatAmount { get; set; }
    public decimal? WTaxAmount { get; set; }
    public long? Utid { get; set; }
    public int? IdCustomer { get; set; }
    public string? IdCurrency { get; set; }
    public int? IdCollectionRegister { get; set; }
    public long? ReversalUtid { get; set; }
    public bool? PostBank1by1 { get; set; }
    public string? PvNumber { get; set; }
    public string? Being { get; set; }
    public string? SecurityNo { get; set; }
    public bool? OpenCheque { get; set; }
    public string IdIManager { get; set; } = null!;
    public string? DbName { get; set; }
    public int? IdCallBack { get; set; }
    public int? IdDisbursementRegister { get; set; }
    public string RefNo { get; set; } = null!;
    public bool? SplitCheque { get; set; }
    public string? ApprovedBy { get; set; }
    public string? IdPayThroughSbu { get; set; }
    public int? IdDepartment { get; set; }
    public bool? AutoSplitCheque { get; set; }
}
