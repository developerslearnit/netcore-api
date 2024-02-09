namespace IbsRestApi.Entities.iMoneytor;

public partial class IbsPostPeriod
{
    public string PostPeriod { get; set; } = null!;
    public DateTime? BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Period { get; set; }
    public bool? Closed { get; set; }
    public bool? YearEnd { get; set; }
    public bool? Locked { get; set; }
}
