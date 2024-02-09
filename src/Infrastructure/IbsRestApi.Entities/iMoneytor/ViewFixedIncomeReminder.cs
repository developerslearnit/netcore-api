namespace IbsRestApi.Entities.iMoneytor;

public partial class ViewFixedIncomeReminder
{
    public string? Id { get; set; }
    public int? LoanId { get; set; }
    public DateTime? ExpectedDate { get; set; }
    public decimal? Amount { get; set; }
    public string PaymentType { get; set; } = null!;
}
