namespace IbsRestApi.Entities.iMoneytor;

public partial class IfrsTempBondHtm
{
    public int? PortFolioId { get; set; }
    public string? PortFolio { get; set; }
    public int? IdPortFoliGroup { get; set; }
    public string? PortFoliGroupName { get; set; }
    public string? Narration { get; set; }
    public DateTime? ValueDate { get; set; }
    public DateTime? MaturityDate { get; set; }
    public decimal? CleanPrice { get; set; }
    public DateTime? IssueDate { get; set; }
    public int? PremiumDiscount { get; set; }
    public decimal? CouponRate { get; set; }
    public decimal? Price { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? MaturityDate1 { get; set; }
    public decimal? OpenBalance { get; set; }
    public decimal? Addition { get; set; }
    public decimal? Disposals { get; set; }
    public decimal? CloseBalance { get; set; }
    public decimal? Received { get; set; }
    public decimal? AccuralBf { get; set; }
    public decimal? AccuralPrd { get; set; }
    public decimal? AccuralCf { get; set; }
    public decimal? MarketValue { get; set; }
}
