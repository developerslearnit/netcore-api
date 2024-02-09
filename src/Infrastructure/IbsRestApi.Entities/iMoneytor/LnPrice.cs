namespace IbsRestApi.Entities.iMoneytor;

public partial class LnPrice
{
    public int SerialNo { get; set; }
    public int? CustomerId { get; set; }
    public int? LoanId { get; set; }
    public string? TickerNo { get; set; }
    public DateTime QoutedDate { get; set; }
    public decimal? OfferPrice { get; set; }
    public decimal? BidPrice { get; set; }
    public string? Symbol { get; set; }
    
}
