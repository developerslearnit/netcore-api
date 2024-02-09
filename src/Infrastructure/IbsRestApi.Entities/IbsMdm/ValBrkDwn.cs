namespace IbsRestApi.Entities.IbsMdm;

public partial class ValBrkDwn
{
    public int IdValBrkDwn { get; set; }
    public string? DatabaseName { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? ValuationDate { get; set; }
    public string? InvestmentModule { get; set; }
    public string? Asset { get; set; }
    public string? AssetClass { get; set; }
    public decimal? AssetValue { get; set; }
    public string? Currency { get; set; }
}
