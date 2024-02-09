namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioUnitHistory
{
    public int IdPortfolioUnitHistory { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? MovementDate { get; set; }
    public decimal? UnitAmount { get; set; }
    public int? IdPortfolioAccount { get; set; }
    public decimal? UnitPrice { get; set; }
    public string? Narration { get; set; }
    public DateTime? ValueDate { get; set; }
    public int? IdPortfolioDirectGldetails { get; set; }
    

    public virtual Portfolio? IdPortfolioNavigation { get; set; }
}
