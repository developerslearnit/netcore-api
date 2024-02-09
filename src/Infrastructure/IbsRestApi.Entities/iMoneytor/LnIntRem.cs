namespace IbsRestApi.Entities.iMoneytor;

public partial class LnIntRem
{
    public int IntReminderId { get; set; }
    public int? IntScheduleId { get; set; }
    public int? LoanId { get; set; }
    public DateTime? ExpectedDate { get; set; }
    public decimal? IntExpected { get; set; }
    public decimal? IntReceived { get; set; }
    public byte? RemiderSent { get; set; }
    public decimal? IntAdjustment { get; set; }
    
}
