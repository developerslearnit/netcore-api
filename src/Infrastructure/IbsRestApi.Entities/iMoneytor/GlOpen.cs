namespace IbsRestApi.Entities.iMoneytor;

public partial class GlOpen
{
    public int IdGlopen { get; set; }
    public string? PostPeriod { get; set; }
    public string? AccountNo { get; set; }
    public decimal? OpenBalance { get; set; }
    public decimal? CloseBalance { get; set; }
}
