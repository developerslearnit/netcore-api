namespace IbsRestApi.Application.IbsMdm;

public class PaymentChannelViewModel
{
    public bool Status { get; set; }

    public string ChannelName { get; set; }

    public string ChannelKey { get; set; }

    public string LiveSecretKey { get; set; }

    public string TestSecretKey { get; set; }

    public string LivePublicKey { get; set; }

    public string TestPublicKey { get; set; }

    public string ChannelLogo { get; set; }
}
