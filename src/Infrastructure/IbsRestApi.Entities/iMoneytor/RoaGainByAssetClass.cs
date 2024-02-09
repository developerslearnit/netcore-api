namespace IbsRestApi.Entities.iMoneytor;

public partial class RoaGainByAssetClass
{
    public int IdRoaGainByAssetClass { get; set; }
    public int? IdPortfolio { get; set; }
    public string? IdInvestmentType { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal? OpenNav { get; set; }
    public decimal? Additions { get; set; }
    public decimal? Disposals { get; set; }
    public decimal? CloseNav { get; set; }
    public decimal? GainLoss { get; set; }
    
}
