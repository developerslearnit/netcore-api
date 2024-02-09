namespace IbsRestApi.Entities.iMoneytor;

public partial class EqPrice
{
    public int QouteId { get; set; }
    public int? ShareId { get; set; }
    public string? TickerNo { get; set; }
    public DateTime QoutedDate { get; set; }
    public decimal? OpenPrice { get; set; }
    public decimal? ChangeInPrice { get; set; }
    public decimal? ClosePrice { get; set; }
    public decimal? HiPrice { get; set; }
    public decimal? LoPrice { get; set; }
    public decimal? Epsh { get; set; }
}
