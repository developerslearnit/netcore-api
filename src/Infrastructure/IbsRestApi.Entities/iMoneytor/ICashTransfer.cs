namespace IbsRestApi.Entities.iMoneytor;

public partial class ICashTransfer
{
    public int IdCashTransfer { get; set; }
    public int? IdTransactionProcess { get; set; }
    public string? Pfacode { get; set; }
    public DateTime? TranDate { get; set; }
    public string? SortCode { get; set; }
    public string? AccountNumber { get; set; }
    public decimal? Amount { get; set; }
    public string? Direction { get; set; }
    public string? TransactionType { get; set; }
    public DateTime? SettlementDate { get; set; }
    
}
