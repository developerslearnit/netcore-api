namespace IbsRestApi.Entities.iMoneytor;

public partial class LnIntRat
{
    public int IntRateId { get; set; }
    public int? FloatingIntType { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public decimal? Rate { get; set; }
    
}
