namespace IbsRestApi.Entities.iMoneytor;

public partial class Tmp68DealDistribution
{
    public int IdDealPrtDistribution { get; set; }
    public int? IdDealMaster { get; set; }
    public int? IdPortfolio { get; set; }
    public int? IdCustomer { get; set; }
    public string? IdDealType { get; set; }
    public DateTime DueDate { get; set; }
    public decimal? Principal { get; set; }
    public decimal? Interest { get; set; }
    public decimal? MarketValue { get; set; }
    public string? Status { get; set; }
}
