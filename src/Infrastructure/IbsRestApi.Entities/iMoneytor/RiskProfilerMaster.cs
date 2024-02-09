namespace IbsRestApi.Entities.iMoneytor;

public partial class RiskProfilerMaster
{
    public int IdRiskProfilerMaster { get; set; }
    public string QuestionCode { get; set; } = null!;
    public string Question { get; set; } = null!;
    public string AnswerControl { get; set; } = null!;
    public string? QuestionImage { get; set; }
    
}
