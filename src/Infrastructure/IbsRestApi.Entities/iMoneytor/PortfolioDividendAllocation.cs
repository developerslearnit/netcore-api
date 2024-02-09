namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioDividendAllocation
{
    public int IdPortfolioDividendAllocation { get; set; }
    public int? IdPortfolioDividendMaster { get; set; }
    public int? IdPortfolioContributor { get; set; }
    public int? IdPortfolio { get; set; }
    public decimal? UnitsOwned { get; set; }
    public decimal? DividendAmount { get; set; }
    public decimal? UnitsAmount { get; set; }
    public string? TreatmentType { get; set; }
    public int? IdPortfolioContributorAccount { get; set; }
    public decimal? OfferPrice { get; set; }
    public DateTime? JoinDate { get; set; }
    public int? NoOfDays { get; set; }
    public bool? Convert2Units { get; set; }
    public decimal? Wac { get; set; }
    public decimal? Balance { get; set; }
    
    public decimal? TodaysProfit { get; set; }

    public virtual PortfolioDividendMaster? IdPortfolioDividendMasterNavigation { get; set; }
}
