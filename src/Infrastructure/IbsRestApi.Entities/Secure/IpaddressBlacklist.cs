namespace IbsRestApi.Entities.Secure;

public partial class IpaddressBlacklist
{
    public long IdIpaddressBlacklist { get; set; }
    public string? LoginId { get; set; }
    public string? Ipaddress { get; set; }
    public string? Country { get; set; }
    public DateTime? AccessDate { get; set; }
    public string? IdApplication { get; set; }
}
