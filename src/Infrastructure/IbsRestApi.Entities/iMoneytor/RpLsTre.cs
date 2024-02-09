namespace IbsRestApi.Entities.iMoneytor;

public partial class RpLsTre
{
    public int RpLsTresId { get; set; }
    public int? LeaseId { get; set; }
    public int? LeaseTypeId { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public decimal? LeaseAmount { get; set; }
    public decimal? LeaseBalance { get; set; }
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
