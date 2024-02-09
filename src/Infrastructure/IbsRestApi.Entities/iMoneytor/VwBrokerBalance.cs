namespace IbsRestApi.Entities.iMoneytor;

public partial class VwBrokerBalance
{
    public string? BrokerId { get; set; }
    public string? IdCurrency { get; set; }
    public int? IdPortfolio { get; set; }
    public decimal? Balance { get; set; }
}
