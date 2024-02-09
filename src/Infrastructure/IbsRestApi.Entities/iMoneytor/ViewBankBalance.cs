namespace IbsRestApi.Entities.iMoneytor;

public partial class ViewBankBalance
{
    public string IdBankAccount { get; set; } = null!;
    public string? AccountName { get; set; }
    public decimal? ClearedBalance { get; set; }
    public decimal? UnClrEffectsReceipts { get; set; }
    public decimal? UnClrEffectsPayments { get; set; }
    public decimal? PostdatedPayments { get; set; }
    public byte? OpenAccount { get; set; }
    public bool? DormiciliaryAccount { get; set; }
}
