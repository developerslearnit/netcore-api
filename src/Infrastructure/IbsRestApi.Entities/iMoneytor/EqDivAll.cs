namespace IbsRestApi.Entities.iMoneytor;

public partial class EqDivAll
{
    public int EqDivAllId { get; set; }
    public int? DividendId { get; set; }
    public string? WarrantNo { get; set; }
    public int? ShareId { get; set; }
    public int? PortfolioId { get; set; }
    public int? PortfolioGroupId { get; set; }
    public string? CrDr { get; set; }
    public decimal? DividendAmount { get; set; }
    public decimal? WithholdingTax { get; set; }
    public DateTime? ReceivedDate { get; set; }
    public DateTime? FinYear { get; set; }
    public int? DeclaredId { get; set; }
    public string? DividendType { get; set; }
    public decimal? ExtraDividend { get; set; }
    
}
