namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsExcRate
{
    public int ExcRateId { get; set; }
    public string? CurrencyId { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public decimal? ExchangeRate { get; set; }

    public virtual IbsCurrency? Currency { get; set; }
}
