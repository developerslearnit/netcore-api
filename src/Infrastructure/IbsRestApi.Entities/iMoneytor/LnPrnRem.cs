namespace IbsRestApi.Entities.iMoneytor;

public partial class LnPrnRem
{
    public int PrnReminderId { get; set; }
    public int? PrnScheduleId { get; set; }
    public int? LoanId { get; set; }
    public DateTime? ExpectedDate { get; set; }
    public decimal? RePaymentRate { get; set; }
    public decimal? PrnRepayment { get; set; }
    public decimal? PrnReceived { get; set; }
    public byte? RemiderSent { get; set; }
    
}
