namespace IbsRestApi.Entities.iMoneytor;

public partial class ValuationCheck
{
    public int IdValuationCheck { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? ValuationDate { get; set; }
    public string? Module { get; set; }
    public string? TableName { get; set; }
    public int? Id2link { get; set; }
    public string? Narration { get; set; }
    public bool? IgnoreRule { get; set; }
    public string? IgnoredBy { get; set; }
    public bool? CannotIgnore { get; set; }
}
