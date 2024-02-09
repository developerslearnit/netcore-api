namespace IbsRestApi.Entities.iMoneytor;

public partial class LnInterestAccrualSchedule
{
    public int IdLnInterestAccrualSchedule { get; set; }
    public int? LoanId { get; set; }
    public DateTime? BeginDate { get; set; }
    public decimal? OpenBalance { get; set; }
    public decimal? PrincipalPaid { get; set; }
    public decimal? Interest { get; set; }
    public decimal? CloseBalance { get; set; }
    public decimal? SumCoupon { get; set; }
    public decimal? ExpCoupon { get; set; }
    public decimal? IntRate { get; set; }
    public DateTime? LastCouponDate { get; set; }
    public DateTime? NextCouponDate { get; set; }
}
