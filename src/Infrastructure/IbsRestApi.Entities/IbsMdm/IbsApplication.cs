namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsApplication
{
    public IbsApplication()
    {
        MessageServers = new HashSet<MessageServer>();
    }

    public string IdApplication { get; set; } = null!;
    public string? Name { get; set; }
    public string? Money4PaymentActNo { get; set; }
    public string? Money4LodgementActNo { get; set; }
    public int? LastVoucherNo { get; set; }
    public int? Lic { get; set; }

    public virtual ICollection<MessageServer> MessageServers { get; set; }
}
