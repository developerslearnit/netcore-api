namespace IbsRestApi.Entities.iMoneytor;

public partial class LnAcrInt
{
    public int TransactionId { get; set; }
    public int LoanId { get; set; }
    public decimal? AccruedInterest { get; set; }
    public string? CrDr { get; set; }
    public string? Narration { get; set; }
    public DateTime? ValueDate { get; set; }
    public byte? Post2Gl { get; set; }
    
}
