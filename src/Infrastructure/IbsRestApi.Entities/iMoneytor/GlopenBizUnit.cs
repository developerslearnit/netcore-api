namespace IbsRestApi.Entities.iMoneytor;

public partial class GlopenBizUnit
{
    public int IdGlopenBizUnit { get; set; }
    public string? IdBranch { get; set; }
    public string? AccountNo { get; set; }
    public string? PostPeriod { get; set; }
    public decimal? OpenBalance { get; set; }
    public decimal? CloseBalance { get; set; }
}
