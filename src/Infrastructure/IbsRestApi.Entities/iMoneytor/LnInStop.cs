namespace IbsRestApi.Entities.iMoneytor;

public partial class LnInStop
{
    public int StopId { get; set; }
    public int LoanId { get; set; }
    public DateTime EffectiveDate { get; set; }
    public string? Narration { get; set; }
    
}
