namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioExpectedReturn
{
    public int IdExpectedReturn { get; set; }
    public int? IdPortfolio { get; set; }
    public string? Narration { get; set; }
    public decimal? Amount { get; set; }
    public decimal? Balance { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal? Rate { get; set; }
    public decimal? Interest { get; set; }
    public int? NoOfDays { get; set; }
    public DateTime? EoqDate { get; set; }
    
}
