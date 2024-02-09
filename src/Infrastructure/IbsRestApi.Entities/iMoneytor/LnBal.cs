namespace IbsRestApi.Entities.iMoneytor;

public partial class LnBal
{
    public int SerialNo { get; set; }
    public int? LoanId { get; set; }
    public DateTime? BeginDate { get; set; }
    public decimal? Balance { get; set; }
    public decimal? IntRate { get; set; }
    public short? NoOfDays { get; set; }
    public DateTime? ValueDate { get; set; }
    public decimal? IntAmount { get; set; }
    public string? Notes { get; set; }
    public string? Post2Gl { get; set; }
    
}
