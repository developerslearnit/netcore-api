namespace IbsRestApi.Entities.iMoneytor;

public partial class DealAccountStatement
{
    public int IdAccountStament { get; set; }
    public int IdReceipt { get; set; }
    public int? IdDealMaster { get; set; }
    public DateTime? TransactionDate { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? Valuedate { get; set; }
    public string? ReceiptFrom { get; set; }
    public string? Being { get; set; }
    public decimal? Amount { get; set; }
    public string? ReceiptType { get; set; }
    public string? SourceBankId { get; set; }
    public string? SourceLocation { get; set; }
    public string? CheqNo { get; set; }
    public string? IdBankAccount { get; set; }
    public string? ReceiptNo { get; set; }
    public string? Status { get; set; }
}
