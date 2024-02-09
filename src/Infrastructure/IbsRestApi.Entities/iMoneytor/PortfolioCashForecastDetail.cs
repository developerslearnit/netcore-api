namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioCashForecastDetail
{
    public int IdPortfolioCashForecastDetail { get; set; }
    public int? IdPortfolioCashForecastMaster { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? ValueDate { get; set; }
    public string? AssetClass { get; set; }
    public string? Narration { get; set; }
    public short? DrCr { get; set; }
    public decimal? Amount { get; set; }
    public bool? IgnoreTransaction { get; set; }
    public bool? SystemCreated { get; set; }
    public string? CapturedBy { get; set; }
    public int? Id2link { get; set; }
    public string IdCashForeCastClass { get; set; } = null!;
    
}
