namespace IbsRestApi.Entities.iMoneytor;

public partial class ExtTrialBalance
{
    public int IdExternalTb { get; set; }
    public string FundId { get; set; } = null!;
    public DateTime? TbDate { get; set; }
    public string? AccountNo { get; set; }
    public string? AccountName { get; set; }
    public decimal? MtdBalance { get; set; }
    public decimal? YtdBalance { get; set; }
    public decimal? Balance { get; set; }
    public string? IbsGlActNo { get; set; }
}
