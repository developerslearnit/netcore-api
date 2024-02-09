namespace IbsRestApi.Entities.IbsMdm;

public partial class Tbprice
{
    public int IdTbprice { get; set; }
    public DateTime? MaturityDate { get; set; }
    public decimal? BidDiscount { get; set; }
    public decimal? BidYield { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public int? IdTransMarket { get; set; }
}
