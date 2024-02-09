namespace IbsRestApi.Entities.iMoneytor;

public partial class TbillResult
{
    public int IdTbillResult { get; set; }
    public int? IdTbillRawData { get; set; }
    public string? ShortName { get; set; }
    public DateTime? ValueDate { get; set; }
    public DateTime? MaturityDate { get; set; }
    public decimal? InterestRate { get; set; }
    public DateTime? IssueDate { get; set; }
    public decimal? CustNoNom { get; set; }
    public string? TranCode { get; set; }
    public decimal? Premium { get; set; }
    public decimal? TotalCost { get; set; }
    public decimal? NetAmount { get; set; }
    public decimal? CustIntrest { get; set; }
    public int? Tenor { get; set; }
    public string? Status { get; set; }
    public int? NoOfDays { get; set; }
    public decimal? WeightedAverage { get; set; }
    public decimal? WeightReturns { get; set; }
    public DateTime? EndDate { get; set; }
}
