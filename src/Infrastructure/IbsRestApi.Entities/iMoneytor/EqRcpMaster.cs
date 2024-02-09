namespace IbsRestApi.Entities.iMoneytor;

public partial class EqRcpMaster
{
    public int IdEqRcpMaster { get; set; }
    public int? IdShare { get; set; }
    public int? SaleId { get; set; }
    public int? IdUnique { get; set; }
    public DateTime? ValueDate { get; set; }
    public string? ReceiptFrom { get; set; }
    public string? Being { get; set; }
    public string? ReceiptType { get; set; }
    public decimal? Amount { get; set; }
    public string? ReceiptNo { get; set; }
    public string? CheqNo { get; set; }
    public string? Status { get; set; }
    public string? VoucherNo { get; set; }
    public int? ReversalId { get; set; }
    public string? IdBank { get; set; }
    public string? IdBankAccount { get; set; }
    public DateTime? SettlementDate { get; set; }
    public int? IdShareMandateDetail { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlPostPeriod { get; set; }
    public decimal? ComChgAmount { get; set; }
    
    public string? CapturedBy { get; set; }
}
