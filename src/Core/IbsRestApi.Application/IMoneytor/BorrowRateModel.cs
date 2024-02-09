namespace IbsRestApi.Application.IMoneytor;

public class BorrowRateModel
{
    public int IdBorrowRateTable { get; set; }
    public string IdBorrowType { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public decimal? FromAmount { get; set; }
    public decimal? ToAmount { get; set; }
    public decimal? IntRate { get; set; }
    public string CapturedBy { get; set; }
    public DateTime? CaptureDate { get; set; }
    public string ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string Comments { get; set; }
    public int? FromTenor { get; set; }
    public int? ToTenor { get; set; }
}


public class BorrowRateResponse
{
    public string effectiveDate { get; set; }
    public decimal? fromAmount { get; set; }
    public decimal? toAmount { get; set; }
    public decimal? interestRate { get; set; }
    public int? fromTenor { get; set; }
    public int? toTenor { get; set; }
}