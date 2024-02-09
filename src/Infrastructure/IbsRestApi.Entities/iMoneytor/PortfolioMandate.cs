namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioMandate
{
    public int IdPortfolioMandate { get; set; }
    public int? IdPortfolio { get; set; }
    public string? Description { get; set; }
    public string? PhotoFileName { get; set; }
    public string? SignatureFileName { get; set; }
    
}
