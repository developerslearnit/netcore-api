namespace IbsRestApi.Entities.iMoneytor;

public partial class TempBlotterTbillUpload
{
    public long IdTempBlotterTbills { get; set; }
    public string? Tradetype { get; set; }
    public string? Portfolio { get; set; }
    public DateTime? Settlementdate { get; set; }
    public string? Countterparty { get; set; }
    public DateTime? Dealdate { get; set; }
    public decimal? Ntbvalue { get; set; }
    public decimal? Discountrate { get; set; }
    public int? Tenor { get; set; }
    public DateTime? Maturitydate { get; set; }
    public decimal? Interest { get; set; }
    public decimal? Discountedvalue { get; set; }
    public string? Broker { get; set; }
    public bool? IsConverted { get; set; }
    public decimal? ExRate { get; set; }
}
