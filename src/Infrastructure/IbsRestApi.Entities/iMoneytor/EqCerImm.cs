namespace IbsRestApi.Entities.iMoneytor;

public partial class EqCerImm
{
    public int ImmobilizeId { get; set; }
    public string? Narration { get; set; }
    public DateTime? ImmobilizeDate { get; set; }
    public decimal? Cost { get; set; }
    public string? CurrencyId { get; set; }
    public int? PortfolioId { get; set; }
    public int? ShareId { get; set; }
    public string? Cscsid { get; set; }
    public string? InvestorActNo { get; set; }
    public int? BankId { get; set; }
    public string? ChequeNo { get; set; }
    public DateTime? TransactionDate { get; set; }
    
}
