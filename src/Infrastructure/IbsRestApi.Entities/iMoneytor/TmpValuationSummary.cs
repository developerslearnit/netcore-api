namespace IbsRestApi.Entities.iMoneytor;

public partial class TmpValuationSummary
{
    public int IdTmpValSummary { get; set; }
    public int IdPortfolio { get; set; }
    public int? IdInvstModule { get; set; }
    public string? InvstDescription { get; set; }
    public decimal? AssetValue { get; set; }
}
