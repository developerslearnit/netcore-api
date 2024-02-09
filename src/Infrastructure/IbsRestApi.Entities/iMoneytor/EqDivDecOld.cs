namespace IbsRestApi.Entities.iMoneytor;

public partial class EqDivDecOld
{
    public int DeclaredId { get; set; }
    public int? AnnualId { get; set; }
    public int? ShareId { get; set; }
    public decimal? DividendRate { get; set; }
    public DateTime? PaymentDate { get; set; }
    public string? DividendType { get; set; }
    public DateTime? ClosureDate { get; set; }
    public byte? RemiderSent { get; set; }
    
    public bool? DoNotPost { get; set; }
}
