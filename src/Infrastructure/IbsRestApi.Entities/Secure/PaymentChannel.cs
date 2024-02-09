namespace IbsRestApi.Entities.Secure;

public partial class PaymentChannel
{
    public int IdPaymentChannel { get; set; }
    public bool Status { get; set; }
    public string ChannelName { get; set; } = null!;
    public string ChannelKey { get; set; } = null!;
    public string LiveSecretKey { get; set; } = null!;
    public string TestSecretKey { get; set; } = null!;
    public string LivePublicKey { get; set; } = null!;
    public string TestPublicKey { get; set; } = null!;
    public string? ChannelLogo { get; set; }
}
