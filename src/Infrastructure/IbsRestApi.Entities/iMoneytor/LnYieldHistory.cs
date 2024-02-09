namespace IbsRestApi.Entities.iMoneytor;

public partial class LnYieldHistory
{
    public int IdYieldHistory { get; set; }
    public int? LoanId { get; set; }
    public decimal? YieldRate { get; set; }
    public DateTime? EffectiveDate { get; set; }
    
}
