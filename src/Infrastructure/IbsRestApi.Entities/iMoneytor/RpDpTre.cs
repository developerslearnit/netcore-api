namespace IbsRestApi.Entities.iMoneytor;

public partial class RpDpTre
{
    public int RpDpTres { get; set; }
    public int DealId { get; set; }
    public int? DealTypeId { get; set; }
    public int? CustomerId { get; set; }
    public string? Narration { get; set; }
    public decimal? Principal { get; set; }
    public decimal? IntRate { get; set; }
    public decimal? EffYeild { get; set; }
    public short? Tenor { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? MaturityDate { get; set; }
    public decimal? IntAtMaturity { get; set; }
    public decimal? IntReceived { get; set; }
    public decimal? InterestOs { get; set; }
    public decimal? InterestAdj { get; set; }
    public string? DealStatus { get; set; }
    public DateTime? EndDate { get; set; }
}
