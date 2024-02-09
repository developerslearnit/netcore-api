namespace IbsRestApi.Entities.iMoneytor;

public partial class Pricelist
{
    public string? Symbol { get; set; }
    public decimal? Pclose { get; set; }
    public decimal? Popen { get; set; }
    public decimal? Low { get; set; }
    public decimal? High { get; set; }
    public decimal? Change { get; set; }
    public DateTime? Dtedate { get; set; }
}
