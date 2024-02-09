namespace IbsRestApi.Entities.iMoneytor;

public partial class LnTmpPrn
{
    public int PrnReminderId { get; set; }
    public int? LoanId { get; set; }
    public DateTime? DueDate { get; set; }
    public decimal? RePaymentRate { get; set; }
    public decimal? PrnRepayment { get; set; }
    
}
