namespace IbsRestApi.Entities.iMoneytor;

public partial class BorrowRateTable
{
    public int IdBorrowRateTable { get; set; }
    public string? IdBorrowType { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public decimal? FromAmount { get; set; }
    public decimal? ToAmount { get; set; }
    public decimal? IntRate { get; set; }
    public string? CapturedBy { get; set; }
    public DateTime? CaptureDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? Comments { get; set; }
    public int? FromTenor { get; set; }
    public int? ToTenor { get; set; }

    public virtual BorrowType? IdBorrowTypeNavigation { get; set; }
}
