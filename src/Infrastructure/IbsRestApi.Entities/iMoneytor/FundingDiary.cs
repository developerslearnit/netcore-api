namespace IbsRestApi.Entities.iMoneytor;

public partial class FundingDiary
{
    public int IdFundingDiary { get; set; }
    public DateTime? ProcessDate { get; set; }
    public string? RunBy { get; set; }
    public DateTime? RunDate { get; set; }
}
