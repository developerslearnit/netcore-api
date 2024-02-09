namespace IbsRestApi.Entities.iMoneytor;

public partial class AiicoDataReportTb
{
    public int? Id2link { get; set; }
    public decimal? CostOfAsset { get; set; }
    public decimal? FaceAmount { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? MaturityDate { get; set; }
    public decimal? InterestRate { get; set; }
    public int? IdPortfolio { get; set; }
    public string? Portfolio { get; set; }
    public string? Description { get; set; }
    public DateTime? ValuationDate { get; set; }
}
