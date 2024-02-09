namespace IbsRestApi.Entities.iMoneytor;

public partial class RiskProfilerDetail
{
    public int IdRiskProfilerDetail { get; set; }
    public int IdRiskProfilerMaster { get; set; }
    public string AnswerCode { get; set; } = null!;
    public string Answer { get; set; } = null!;
    public decimal? RiskFactor { get; set; }
    public decimal? TimingFactor { get; set; }
    
}
