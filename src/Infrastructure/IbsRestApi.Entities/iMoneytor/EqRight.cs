namespace IbsRestApi.Entities.iMoneytor;

public partial class EqRight
{
    public int RightId { get; set; }
    public int? ShareId { get; set; }
    public string? RightType { get; set; }
    public string? Narration { get; set; }
    public short? Rate { get; set; }
    public short? ForShares { get; set; }
    public string? BrokerId { get; set; }
    public DateTime? QualifyDate { get; set; }
    public int? QualifyQty { get; set; }
    public decimal? UnitCost { get; set; }
    public DateTime? ClosureDate { get; set; }
    public decimal? BuyPrice { get; set; }
    public int? RightQty { get; set; }
    public int? RightTaken { get; set; }
    public decimal? RightCost { get; set; }
    public int? QtySold { get; set; }
    public int? UniqueId { get; set; }
    public int? ExtraQty { get; set; }
    public decimal? ExtraCost { get; set; }
    public int? DepositId { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public int? ReversalId { get; set; }
    public string? TransType { get; set; }
    public DateTime? SettlementDate { get; set; }
    public decimal? ExtraUnitCost { get; set; }
    
}
