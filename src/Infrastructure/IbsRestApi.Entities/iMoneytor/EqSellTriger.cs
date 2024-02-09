namespace IbsRestApi.Entities.iMoneytor;

public partial class EqSellTriger
{
    public int IdSellTriger { get; set; }
    public string? Description { get; set; }
    public decimal? SellProfitMargin { get; set; }
    public decimal? SellAtPrice { get; set; }
    
}
