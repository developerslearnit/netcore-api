namespace IbsRestApi.Entities.iMoneytor;

public partial class ForexRevaluationDetail
{
    public int IdForexRevaluationDetails { get; set; }
    public int? IdForexRevaluationMaster { get; set; }
    public int? IdPortfolio { get; set; }
    public string? InvestmentModule { get; set; }
    public string? IdInvestmentType { get; set; }
    public int? Id2link { get; set; }
    public string? Narration { get; set; }
    public DateTime? PrevDate { get; set; }
    public decimal? PrevExRate { get; set; }
    public DateTime? CurrDate { get; set; }
    public decimal? CurrExRate { get; set; }
    public decimal? GainLoss { get; set; }
    
}
