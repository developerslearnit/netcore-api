namespace IbsRestApi.Entities.iMoneytor;

public partial class IbsApplication
{
    public string IdApplication { get; set; } = null!;
    public string? Name { get; set; }
    public string? Money4PaymentActNo { get; set; }
    public string? Money4LodgementActNo { get; set; }
    public int? LastVoucherNo { get; set; }
    public int? Lic { get; set; }
}
