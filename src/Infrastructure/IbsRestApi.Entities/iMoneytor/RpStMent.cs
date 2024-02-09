namespace IbsRestApi.Entities.iMoneytor;

public partial class RpStMent
{
    public int RpStMent1 { get; set; }
    public int? LinkId { get; set; }
    public DateTime? ValueDate { get; set; }
    public decimal? OpenBalance { get; set; }
    public string? Narration { get; set; }
    public int? NoOfDays { get; set; }
    public decimal? IntRate { get; set; }
    public decimal? InterestBf { get; set; }
    public decimal? AccruedInterest { get; set; }
    public decimal? AmtRecd { get; set; }
    public decimal? PrnRecd { get; set; }
    public decimal? IntRecd { get; set; }
    public decimal? Additions { get; set; }
    public decimal? CloseBalance { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
}
