namespace IbsRestApi.Entities.iMoneytor;

public partial class Logging
{
    public int InternalId { get; set; }
    public string? UserId { get; set; }
    public string? SessionId { get; set; }
    public string? ProcedureName { get; set; }
    public string? TableName { get; set; }
    public string? ActionDone { get; set; }
    public string? Pk { get; set; }
    public DateTime? Audit { get; set; }
    public string? Ip { get; set; }
}
