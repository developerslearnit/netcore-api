namespace IbsRestApi.Entities.iMoneytor;

public partial class BorrowTmpPayoutSchedule
{
    public int IdBorrowTmpPayoutSchedule { get; set; }
    public int? IdBorrowMaster { get; set; }
    public int? IdPortfolioContributor { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? BeginDate { get; set; }
    public int? InterestDays { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal? Amount { get; set; }
    public decimal? WithHoldTaxAmount { get; set; }
    public decimal? Amount2Pay { get; set; }
    public string? IdCurrency { get; set; }
    public string? CustomerName { get; set; }
}
