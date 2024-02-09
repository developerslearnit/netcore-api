namespace IbsRestApi.Entities.iMoneytor;

public partial class LnPrnSch
{
    public int PrnScheduleId { get; set; }
    public int? LoanId { get; set; }
    public string? PrnPaymentType { get; set; }
    public string? PrnPaymentGap { get; set; }
    public DateTime? PrnStartDate { get; set; }
    public short? PrnEndAfter { get; set; }
    public DateTime? PrnEndDate { get; set; }
    public string? PrnStatus { get; set; }
    
}
