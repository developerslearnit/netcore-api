namespace IbsRestApi.Entities.iMoneytor;

public partial class TmpEquityReturn
{
    public int LineId { get; set; }
    public string? Fund { get; set; }
    public decimal? CurrentValue { get; set; }
    public decimal? YtdsaleDividend { get; set; }
    public decimal? BeginValue { get; set; }
    public decimal? Ytdpurchase { get; set; }
    public decimal? FundReturns { get; set; }
}
