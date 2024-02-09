namespace IbsRestApi.Entities.iMoneytor;

public partial class EqDividendBf
{
    public int IdDividendBf { get; set; }
    public int? ShareId { get; set; }
    public int? IdPortfolio { get; set; }
    public string? Narration { get; set; }
    public DateTime? OpenDate { get; set; }
    public decimal? Amount { get; set; }
    
}
