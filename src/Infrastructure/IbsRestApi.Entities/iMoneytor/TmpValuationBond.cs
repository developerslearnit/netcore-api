namespace IbsRestApi.Entities.iMoneytor;

public partial class TmpValuationBond
{
    public int IdValBond { get; set; }
    public int? IdPortfolio { get; set; }
    public int? Id2link { get; set; }
    public string? SecurityName { get; set; }
    public DateTime? TransDate { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public string? Narration { get; set; }
    public decimal? Qty { get; set; }
    public decimal? TotalCost { get; set; }
    public decimal? GainLoss { get; set; }
    public decimal? AssetValue { get; set; }
}
