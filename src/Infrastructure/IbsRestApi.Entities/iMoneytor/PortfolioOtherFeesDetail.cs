namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioOtherFeesDetail
{
    public int IdOtherFeesDetails { get; set; }
    public int? IdOtherFeesMaster { get; set; }
    public decimal? BeginAmount { get; set; }
    public decimal? EndAmount { get; set; }
    public decimal? OthFeesRate { get; set; }

    public virtual PortfolioOtherFeesMaster? IdOtherFeesMasterNavigation { get; set; }
}
