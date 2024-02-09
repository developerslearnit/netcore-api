namespace IbsRestApi.Entities.iMoneytor;

public partial class FixedInterestPaymentDetail
{
    public int IdFixedInterestPaymentDetail { get; set; }
    public int? IdFixedInterestPaymentMaster { get; set; }
    public int? IdBorrowMaster { get; set; }
    public DateTime? BeginDate { get; set; }
    public int? InterestDays { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal? Amount { get; set; }
    public string? BankId { get; set; }
    public string? AccountNo { get; set; }
    public bool? Posted { get; set; }
    public decimal? WithHoldTaxAmount { get; set; }
    public decimal? Amount2Pay { get; set; }
    public string? IdCurrency { get; set; }
    public string? AccountName { get; set; }
    public string? SuppressNote { get; set; }
    public string? CustomerName { get; set; }
}
