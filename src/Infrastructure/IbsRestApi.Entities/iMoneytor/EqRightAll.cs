namespace IbsRestApi.Entities.iMoneytor;

public partial class EqRightAll
{
    public int IdRightAllocation { get; set; }
    public int? RightId { get; set; }
    public int? PortfolioId { get; set; }
    public int? QtyUnit { get; set; }
    public decimal? AllocatedCost { get; set; }
    public int? ExtraQty { get; set; }
    public decimal? ExtraCost { get; set; }
    
}
