namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsPaymentChannelBankAccount
{
    public int IdIbsPaymentChannelBankAccount { get; set; }
    public string? IdApplication { get; set; }
    public string? PaymentMethod { get; set; }
    public string? IdBankAccount { get; set; }
    public string? NibssBillerAccountCode { get; set; }
}
