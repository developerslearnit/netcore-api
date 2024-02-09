namespace IbsRestApi.Entities.iMoneytor;

public partial class MergerLink
{
    public int IdMargerLink { get; set; }
    public string? DatabaseName { get; set; }
    public string? TableName { get; set; }
    public string? OldLinkKey { get; set; }
    public string? NewLinkKey { get; set; }
}
