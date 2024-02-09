namespace IbsRestApi.Entities.iMoneytor;

public partial class Loan2CovertAmortSchedule
{
    public long IdBondIrr { get; set; }
    public int? IdLoan2Convert { get; set; }
    public int? PrdNo { get; set; }
    public DateTime? DueDate { get; set; }
    public decimal? Amount { get; set; }
    public decimal? PrnBf { get; set; }
    public decimal? IrrIntAmount { get; set; }
    public decimal? AmortAmount { get; set; }
    public decimal? PrnCf { get; set; }
    public int? NoOfDays { get; set; }
    public DateTime? BeginDate { get; set; }
}
