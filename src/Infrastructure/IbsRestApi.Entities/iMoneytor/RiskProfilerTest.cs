namespace IbsRestApi.Entities.iMoneytor;

public partial class RiskProfilerTest
{
    public int IdRiskProfilerTest { get; set; }
    public int IdPortfolio { get; set; }
    public int IdRiskProfilerMaster { get; set; }
    public int IdRiskProfilerDetail { get; set; }
    public string? AnswerCode { get; set; }
    public decimal? RiskFactor { get; set; }
    public decimal? TimingFactor { get; set; }
    
}
