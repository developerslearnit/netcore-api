namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioIncentive
{
    public int IdPortfolioIncentive { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? ProcessDate { get; set; }
    public DateTime? DueDate { get; set; }
    public string? Narration { get; set; }
    public decimal? Amount { get; set; }
    public int? PosAmount { get; set; }
    public int? FontAttribute { get; set; }
    public int? BorderAttribute { get; set; }
    public short? RepeatAmount { get; set; }
    
}
