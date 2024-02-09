namespace IbsRestApi.Entities.iMoneytor;

public partial class BorrowInternalTransfer
{
    public int IdBorrowInternalTransfer { get; set; }
    public DateTime? TransferDate { get; set; }
    public string? TransferType { get; set; }
    public string? Narration { get; set; }
    public decimal? Amount { get; set; }
    public string? PrepairedBy { get; set; }
    public int? FromBorrowId { get; set; }
    public int? ToBorrowId { get; set; }
    public string? IdBranch { get; set; }
    public string? VoucherNo { get; set; }
    public bool? Reversed { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? PostedBy { get; set; }
    public int? FromIdConrtributor { get; set; }
    public int? ToIdConrtributor { get; set; }
    public int? IdPortfolio { get; set; }
    public string? IdCurrency { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
}
