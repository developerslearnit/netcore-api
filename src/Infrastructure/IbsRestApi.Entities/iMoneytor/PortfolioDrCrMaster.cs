namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioDrCrMaster
{
    public int IdPortfolioDrCrMaster { get; set; }
    public int? IdPortfolio { get; set; }
    public string? IdInvestmentType { get; set; }
    public decimal? Amount { get; set; }
    public string? Narration { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? NoOfDays { get; set; }
    public decimal? WriteOffPerDay { get; set; }
    public string? DrAccountNo { get; set; }
    public string? CrAccountNo { get; set; }
    public string? Status { get; set; }
    public DateTime? LastPostDate { get; set; }
    public string? Comments { get; set; }
    
    public bool? Include4YieldCalculation { get; set; }
    public decimal? AccrualBf { get; set; }
    public bool? IncludeInDailyIncomeExpense { get; set; }
    public bool? DoNotTreatAsFees { get; set; }
}
