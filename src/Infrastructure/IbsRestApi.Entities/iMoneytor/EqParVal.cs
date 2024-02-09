namespace IbsRestApi.Entities.iMoneytor;

public partial class EqParVal
{
    public string ParValueId { get; set; } = null!;
    public int ShareId { get; set; }
    public decimal? ParValue { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public string? Narration { get; set; }
    public DateTime? SettlementDate { get; set; }
    
}
