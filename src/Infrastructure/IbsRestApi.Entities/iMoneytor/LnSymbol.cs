namespace IbsRestApi.Entities.iMoneytor;

public partial class LnSymbol
{
    public string Symbol { get; set; } = null!;
    public int? IdCustomer { get; set; }
    public string? Description { get; set; }
    public decimal? QtyIssued { get; set; }
    public decimal? AmountIssued { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Rating { get; set; }
    public string? PrnPaymentType { get; set; }
    public string? PrnPaymentGap { get; set; }
    public DateTime? PrnStartDate { get; set; }
    public short? PrnEndAfter { get; set; }
    public DateTime? PrnEndDate { get; set; }
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
    public string? ResetFloatGap { get; set; }
    public DateTime? LastResetDate { get; set; }
    public int? PrnFrequeny { get; set; }
    public int? IntFrequeny { get; set; }
    public int? Tenor { get; set; }
    public string? DaysInYear { get; set; }
    public int? ResetFloatGapDays { get; set; }
    public string? IdCurrency { get; set; }
    public int? LoanTypeId { get; set; }
    public decimal? RepaymentRate { get; set; }
    public bool? ForceEom { get; set; }
    public bool? EqualCouponPayment { get; set; }
    
    public int? DaysBasis { get; set; }
}
