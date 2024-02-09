namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioOtherFeesMaster
{
    public PortfolioOtherFeesMaster()
    {
        PortfolioOtherFeesDetails = new HashSet<PortfolioOtherFeesDetail>();
    }

    public int IdOtherFeesMaster { get; set; }
    public int? IdPortfolio { get; set; }
    public string? OtherFeesName { get; set; }
    public string? OtherFeesPer { get; set; }
    public bool? ReducingBalanceMetod { get; set; }
    public string? OtherNavType { get; set; }
    public string? OtherFeeExpActNo { get; set; }
    public string? OtherFeePayableActNo { get; set; }
    public string? OtherFeeVatExpActNo { get; set; }
    public string? OtherFeeVatPaybleActNo { get; set; }

    public virtual Portfolio? IdPortfolioNavigation { get; set; }
    public virtual ICollection<PortfolioOtherFeesDetail> PortfolioOtherFeesDetails { get; set; }
}
