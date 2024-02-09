namespace IbsRestApi.Entities.iMoneytor;

public partial class TmpValuationCash
{
    public int IdValCash { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? TransDate { get; set; }
    public DateTime? ValueDate { get; set; }
    public string? Narration { get; set; }
    public decimal? AmountCr { get; set; }
    public decimal? AmountDb { get; set; }
    public decimal? AmountCf { get; set; }
}
