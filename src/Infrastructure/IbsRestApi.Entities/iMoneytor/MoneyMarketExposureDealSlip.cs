namespace IbsRestApi.Entities.iMoneytor;

public partial class MoneyMarketExposureDealSlip
{
    public int IdMoneyMarketExposureDealSlip { get; set; }
    public int? IdMoneyMarketExposureMaster { get; set; }
    public int? NoOfDays { get; set; }
    public decimal? DealSlipAmount { get; set; }
    public int? IdPortfolioCashForecastMaster { get; set; }
    public string? IdDealType { get; set; }
    
}
