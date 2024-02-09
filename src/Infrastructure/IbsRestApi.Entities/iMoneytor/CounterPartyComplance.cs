namespace IbsRestApi.Entities.iMoneytor;

public partial class CounterPartyComplance
{
    public int IdCounterPartyComplance { get; set; }
    public int? IdCustomer { get; set; }
    public int? IdPortfolio { get; set; }
    public decimal? NetAssetValue { get; set; }
    public string? IdCurrency { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal? MaxExposureRate { get; set; }
    public int? IdReateEngine { get; set; }
    public decimal? CustomerLimit { get; set; }
    public decimal? CustomerExposure { get; set; }
    public decimal? MoneyMarketLimit { get; set; }
    public decimal? MoneyMarketExposure { get; set; }
    public decimal? EquityLimit { get; set; }
    public decimal? EquityExposure { get; set; }
    public decimal? BondLimit { get; set; }
    public decimal? BondExposure { get; set; }
    public decimal? RealEstateLimit { get; set; }
    public decimal? RealEstateExposure { get; set; }
    
}
