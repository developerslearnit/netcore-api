namespace IbsRestApi.Entities.iMoneytor;

public partial class SecUser
{
    public string Uid { get; set; } = null!;
    public int? XUsrId { get; set; }
    public string? Pwd { get; set; }
    public string? FullName { get; set; }
    public string? IdLocation { get; set; }
    public bool? Chk { get; set; }
    public string? EmailAddress { get; set; }
    public decimal? ApprovalLimit { get; set; }
}
