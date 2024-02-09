namespace IbsRestApi.Entities.iMoneytor;

public partial class TrailBalance
{
    public string? AccountNo { get; set; }
    public string? PostPeriod { get; set; }
    public decimal? DrAmount { get; set; }
    public decimal? CrAmount { get; set; }
    public decimal? Amount { get; set; }
}
