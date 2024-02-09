namespace IbsRestApi.Entities.iMoneytor;

public partial class RpEqExp
{
    public int RpEqExp1 { get; set; }
    public int ShareId { get; set; }
    public int? SectorId { get; set; }
    public DateTime? YearEnd { get; set; }
    public decimal? NorminalValue { get; set; }
    public int? TotalShares { get; set; }
    public decimal? IntDividendExp { get; set; }
    public decimal? FinalDivDeclared { get; set; }
    public decimal? FinDividendExp { get; set; }
    public DateTime? DatePayable { get; set; }
    public decimal? DivReceived { get; set; }
    public string? BonusDeclred { get; set; }
    public int? BonusExpected { get; set; }
    public int? BonusReceived { get; set; }
    public DateTime? ClosureDate { get; set; }
    public DateTime? EndDate { get; set; }
}
