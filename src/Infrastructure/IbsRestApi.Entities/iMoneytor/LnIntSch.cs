namespace IbsRestApi.Entities.iMoneytor;

public partial class LnIntSch
{
    public int IntScheduleId { get; set; }
    public int? LoanId { get; set; }
    public string? InterestType { get; set; }
    public decimal? FixedInterestRate { get; set; }
    public int? FloatingIntType { get; set; }
    public decimal? Add2BaseInterestRate { get; set; }
    public decimal? EffectiveIntRate { get; set; }
    public decimal? MinInterestRate { get; set; }
    public decimal? MaxInterestRate { get; set; }
    public string? IntPaymentGap { get; set; }
    public DateTime? IntStartDate { get; set; }
    public short? IntEndAfter { get; set; }
    public DateTime? IntEndDate { get; set; }
    public string? IntStatus { get; set; }
    public string? ResetFloatGap { get; set; }
    public DateTime? LastResetDate { get; set; }
    public decimal? FloatingIntRateInUse { get; set; }
    
}
