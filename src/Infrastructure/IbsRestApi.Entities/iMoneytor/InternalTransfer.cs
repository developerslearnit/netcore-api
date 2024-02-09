namespace IbsRestApi.Entities.iMoneytor;

public partial class InternalTransfer
{
    public int IdInternalTransfer { get; set; }
    public DateTime? TransferDate { get; set; }
    public string? TransferType { get; set; }
    public string? Narration { get; set; }
    public decimal? Amount { get; set; }
    public string? PrepairedBy { get; set; }
    public int? FromDealId { get; set; }
    public int? ToDealId { get; set; }
    public string? IdBranch { get; set; }
    public string? VoucherNo { get; set; }
    public bool? Reversed { get; set; }
    public DateTime? SettlementDate { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlPostPeriod { get; set; }
    
}
