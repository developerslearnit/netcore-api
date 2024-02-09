namespace IbsRestApi.Entities.iMoneytor;

public partial class LnRepaySchedule
{
    public int IdLnRepaySchedule { get; set; }
    public int? LoanId { get; set; }
    public DateTime? DueDate { get; set; }
    public decimal? OpenBalance { get; set; }
    public decimal? Amount { get; set; }
    public decimal? PrnAmount { get; set; }
    public decimal? IntAmount { get; set; }
    public decimal? CloseBalance { get; set; }
    public bool? Posted { get; set; }
    public decimal? IntPerDay { get; set; }
    public string? VoucherNo { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlPostPeriod { get; set; }
    public bool? Reversed { get; set; }
    public int? ReversalId { get; set; }
    
}
