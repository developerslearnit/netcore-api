namespace IbsRestApi.Entities.iMoneytor;

public partial class AnReport
{
    public int AnnualId { get; set; }
    public int? ShareId { get; set; }
    public string? FinYear { get; set; }
    public string? BonusRate { get; set; }
    public string? BonusFor { get; set; }
    public DateTime? BonusCloseDate { get; set; }
    public string? Rating { get; set; }
    public decimal? ProfitAfterTaxQ1 { get; set; }
    public decimal? ProfitAfterTaxQ2 { get; set; }
    public decimal? ProfitAfterTaxQ3 { get; set; }
    public decimal? ProfitAfterTax { get; set; }
    public decimal? TurnOverQ1 { get; set; }
    public decimal? TurnOverQ2 { get; set; }
    public decimal? TurnOverQ3 { get; set; }
    public decimal? TurnOver { get; set; }
    public decimal? ShareInIssue { get; set; }
    public decimal? PeRatio { get; set; }
    public decimal? Eps { get; set; }
    
    public DateTime? BonusClosureDate { get; set; }
    public string? Symbol { get; set; }
    public bool? DoNotPost { get; set; }
    public int? IdCorporateActionMaster { get; set; }
}
