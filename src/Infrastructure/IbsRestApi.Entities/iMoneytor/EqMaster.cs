namespace IbsRestApi.Entities.iMoneytor;

public partial class EqMaster
{
    public int ShareId { get; set; }
    public string? InvestType { get; set; }
    public string? Name { get; set; }
    public int? CustomerId { get; set; }
    public string? CurencyId { get; set; }
    public string? RegistrarId { get; set; }
    public string? ShareType { get; set; }
    public decimal? NorminalValue { get; set; }
    public decimal? TotalUnits { get; set; }
    public decimal? Cscsunits { get; set; }
    public decimal? CertificatedUnits { get; set; }
    public decimal? TotalCost { get; set; }
    public decimal? AverageCost { get; set; }
    public DateTime? LastTranDate { get; set; }
    public string? StockExchangeId { get; set; }
    public int? QoutedAtId { get; set; }
    public string? Symbol { get; set; }
    public decimal? IssuedShares { get; set; }
    public decimal? ShareCapital { get; set; }
    public string? Rating { get; set; }
    
}
