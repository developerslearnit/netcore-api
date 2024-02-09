namespace IbsRestApi.Entities.iMoneytor;

public partial class BorrowCashMgtDateUpdate
{
    public int IdBorrowCashMgtDateUpdate { get; set; }
    public int? IdPortfolioContributor { get; set; }
    public int? IdPortfolioContributorAccount { get; set; }
    public string? ReasonForChange { get; set; }
    public DateTime? ChangeFromDate { get; set; }
    public DateTime? ChangeToDate { get; set; }
    public string? RequestBy { get; set; }
    public DateTime? RequestDate { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovalDate { get; set; }
    public string? Status { get; set; }
}
