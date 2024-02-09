namespace IbsRestApi.Entities.iMoneytor;

public partial class TmpValuation04
{
    public int IdTmpValuation04 { get; set; }
    public DateTime? ValueDate { get; set; }
    public string? ShareName { get; set; }
    public decimal? Units { get; set; }
    public decimal? Consideration { get; set; }
    public decimal? Brokerage { get; set; }
    public decimal? StampDuty { get; set; }
    public decimal? Nsefees { get; set; }
    public decimal? Cscsfees { get; set; }
    public decimal? SecFees { get; set; }
    public decimal? Vat { get; set; }
    public decimal? OtherFees { get; set; }
    public decimal? TotalFees { get; set; }
    public decimal? GrossAmount { get; set; }
    public short? FontAttribute { get; set; }
    public string? TransactionType { get; set; }
    public int? PortfolioId { get; set; }
}
