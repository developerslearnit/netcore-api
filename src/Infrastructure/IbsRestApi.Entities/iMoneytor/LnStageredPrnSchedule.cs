namespace IbsRestApi.Entities.iMoneytor;

public partial class LnStageredPrnSchedule
{
    public int IdStageredPrnSchedule { get; set; }
    public string? Symbol { get; set; }
    public DateTime? DueDate { get; set; }
    public decimal? PrnPercentDue { get; set; }
    public decimal? RepaymentRate { get; set; }
}
