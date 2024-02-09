namespace IbsRestApi.Entities.iMoneytor;

public partial class BorrowCashMgtAccount
{
    public string IdCashMgtAccount { get; set; } = null!;
    public string? TransactionType { get; set; }
    public string? CashMgtAccountName { get; set; }
    public string? GlactNo { get; set; }
}
