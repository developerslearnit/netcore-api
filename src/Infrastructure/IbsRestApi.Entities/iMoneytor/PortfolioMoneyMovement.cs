namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioMoneyMovement
{
    public int IdPortfolioMoneyMovement { get; set; }
    public int? IdPortfolio { get; set; }
    public string? IdInvestmentType { get; set; }
    public DateTime? TransactionDate { get; set; }
    public DateTime? ValueDate { get; set; }
    public decimal? Amount { get; set; }
    public string? Narration { get; set; }
    public string? IdCurrency { get; set; }
    public decimal? CurExRate { get; set; }
    public string? VoucherNo { get; set; }
    public string? TrackCode { get; set; }
    public int? ReversalId { get; set; }
    public short? Injection { get; set; }
    public string? Status { get; set; }
    public string? CapturedBy { get; set; }
    public string? ApprovedBy { get; set; }
    public string? Comments { get; set; }
    public int? IdPortfolioAccount { get; set; }
    public string? BankGlActNo { get; set; }
    public string? MainAccount { get; set; }
    public string? TransactionType { get; set; }
    public string? DocumentHyperLink { get; set; }
    public bool? CalculateRebate { get; set; }
    public decimal? NoOfUnits { get; set; }
    
    public bool? DoNotExportToExternalGl { get; set; }
    public bool? MoveCashToActPayble { get; set; }
}
