namespace IbsRestApi.Entities.iMoneytor;

public partial class LogSettlementConfirmation
{
    public int IdLogSettlementConfirmation { get; set; }
    public int? IdLogMaster { get; set; }
    public DateTime? CreationDate { get; set; }
    public string? SfkaccountCode { get; set; }
    public string? TradeReference { get; set; }
    public string? TradeCode { get; set; }
    public string? DataFileName { get; set; }
    public string? Problem { get; set; }
    public bool? Treated { get; set; }
    public string? Comments { get; set; }
    public string? SymBol { get; set; }
    public int? Qty { get; set; }
    public decimal? Amount { get; set; }
    
}
