namespace IbsRestApi.Entities.IbsMdm;

public partial class VfdBankOutwardTransferLog
{
    public int InflowTransferId { get; set; }
    public string FromAccount { get; set; } = null!;
    public string FromClient { get; set; } = null!;
    public string ToAccount { get; set; } = null!;
    public string ToBank { get; set; } = null!;
    public decimal Amount { get; set; }
    public string TransRef { get; set; } = null!;
    public string ToClient { get; set; } = null!;
    public DateTime TransactionDate { get; set; }
}
