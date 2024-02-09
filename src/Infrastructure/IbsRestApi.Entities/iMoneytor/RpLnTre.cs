namespace IbsRestApi.Entities.iMoneytor;

public partial class RpLnTre
{
    public int RpLnTres { get; set; }
    public int? LoanId { get; set; }
    public int? LoanTypeId { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public decimal? LoanAmount { get; set; }
    public DateTime? MaturityDate { get; set; }
    public string? Red1Due { get; set; }
    public string? Red2Due { get; set; }
    public decimal? RePayment { get; set; }
    public decimal? LoanBalance { get; set; }
    public short? Pay1Due { get; set; }
    public short? Pay2Due { get; set; }
    public decimal? PrnDue { get; set; }
    public string? Int1Due { get; set; }
    public string? Int2Due { get; set; }
    public decimal? IntRate { get; set; }
    public DateTime? IntDueDate { get; set; }
    public decimal? IntAtDueDate { get; set; }
    public decimal? IntAtRepDate { get; set; }
    public DateTime? EndDate { get; set; }
    
}
