namespace IbsRestApi.Entities.iMoneytor;

public partial class RpMgTre
{
    public int RpMgTresId { get; set; }
    public int? MortgageId { get; set; }
    public int? MortgageTypeId { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public decimal? MorgageAmount { get; set; }
    public decimal? MorgBalance { get; set; }
    public DateTime? MaturityDate { get; set; }
    public decimal? RepayAmt { get; set; }
    public string? PayGap { get; set; }
    public short? Red1Due { get; set; }
    public short? Red2Due { get; set; }
    public decimal? Due2Date { get; set; }
    public decimal? IntRate { get; set; }
    public string? DueDates { get; set; }
    public DateTime? EndDate { get; set; }
}
