namespace IbsRestApi.Entities.iMoneytor;

public partial class IbsVoucherNo
{
    public int IdVoucher { get; set; }
    public string VoucherNo { get; set; } = null!;
    public string? IdBranch { get; set; }
    public string? Title { get; set; }
    public string PostPeriod { get; set; } = null!;
    public string? IdApplication { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? PostedBy { get; set; }
    public bool? DoNotExportToExternalGl { get; set; }
    public string? PostDay { get; set; }
    public string? PostWeek { get; set; }
    public string? PrepairedBy { get; set; }
}
