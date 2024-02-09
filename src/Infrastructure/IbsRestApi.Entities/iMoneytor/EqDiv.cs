namespace IbsRestApi.Entities.iMoneytor;

public partial class EqDiv
{
    public int DividendId { get; set; }
    public int? ShareId { get; set; }
    public int? DeclaredId { get; set; }
    public int? AdjustId { get; set; }
    public byte? ExScrip { get; set; }
    public decimal? ScripPrice { get; set; }
    public decimal? ScripCost { get; set; }
    public string? WarrantNo { get; set; }
    public int? UniqueId { get; set; }
    public string? Narration { get; set; }
    public DateTime? ReceivedDate { get; set; }
    public string? CurrencyId { get; set; }
    public string? CrDr { get; set; }
    public decimal? DividendAmount { get; set; }
    public decimal? WithholdingTax { get; set; }
    public string? BankId { get; set; }
    public DateTime? FinYear { get; set; }
    public string? DividendType { get; set; }
    public decimal? ExtraDividend { get; set; }
    public decimal? DividendRefund { get; set; }
    public string? VoucherNo { get; set; }
    public int? ReversalId { get; set; }
    public DateTime? SettlementDate { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlPostPeriod { get; set; }
    public string? Comments { get; set; }
    public string? Status { get; set; }
    public bool? Paid2Client { get; set; }
    
    public int? DeclaredIdSave { get; set; }
    public string? CapturedBy { get; set; }
}
