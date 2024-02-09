namespace IbsRestApi.Entities.iMoneytor;

public partial class RoaTimeWeightedDetail
{
    public int IdRoaTimeWeightedDetails { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? ValueDate { get; set; }
    public int? DaysCount { get; set; }
    public decimal? CapMrkCashFlow { get; set; }
    public decimal? MonMrkCashFlow { get; set; }
    public decimal? TbillCashFlow { get; set; }
    public decimal? BndMrkCashFlow { get; set; }
    public decimal? BndSbCashFlow { get; set; }
    public decimal? BndCbCashFlow { get; set; }
    public decimal? RelEstCashFlow { get; set; }
    public decimal? DayWeihgt { get; set; }
    public decimal? WeigthCapMrk { get; set; }
    public decimal? WeigthMonMrk { get; set; }
    public decimal? WeigthTbill { get; set; }
    public decimal? WeigthBndMrk { get; set; }
    public decimal? WeigthBndSb { get; set; }
    public decimal? WeigthBndCb { get; set; }
    public decimal? WeigthRelEst { get; set; }
    public int? IdRoaPortfolioTimeWeightedReturns { get; set; }
    public decimal? EqChange { get; set; }
    public decimal? WeigthPrvEqt { get; set; }
    public decimal? WeigthMutualFund { get; set; }
}
