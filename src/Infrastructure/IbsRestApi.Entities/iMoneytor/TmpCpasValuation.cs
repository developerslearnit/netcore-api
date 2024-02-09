namespace IbsRestApi.Entities.iMoneytor;

public partial class TmpCpasValuation
{
    public int IdCpasValuation { get; set; }
    public decimal? OpenNav { get; set; }
    public string? Description { get; set; }
    public decimal? Amount01 { get; set; }
    public decimal? MarketValue { get; set; }
    public int? FontAttribute { get; set; }
    public decimal? ForexAmount { get; set; }
    public decimal? ExRate { get; set; }
    public string? Arrangement { get; set; }
    public DateTime? ValuationDate { get; set; }
}
