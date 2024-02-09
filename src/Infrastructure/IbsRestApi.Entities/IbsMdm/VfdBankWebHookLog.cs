namespace IbsRestApi.Entities.IbsMdm;

public partial class VfdBankWebHookLog
{
    public int WebHookReqId { get; set; }
    public string RawPayload { get; set; } = null!;
    public string ReferenceNo { get; set; } = null!;
    public decimal Amount { get; set; }
    public string WalletAccountNo { get; set; } = null!;
    public string OriginAccount { get; set; } = null!;
    public string OriginAccountName { get; set; } = null!;
    public string OriginBank { get; set; } = null!;
    public string OriginNarration { get; set; } = null!;
    public string TransactionTimeStamp { get; set; } = null!;
    public DateTime DateLogged { get; set; }
}
