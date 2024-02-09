namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioUnitSwap
{
    public int IdUnitSwap { get; set; }
    public int? IdPortfolioContributor { get; set; }
    public string? Narration { get; set; }
    public DateTime? TransferDate { get; set; }
    public int? FromPortfolioId { get; set; }
    public decimal? FromQtyBf { get; set; }
    public decimal? TransferOutQty { get; set; }
    public decimal? BidPrice { get; set; }
    public decimal? TransferFees { get; set; }
    public decimal? TransferOutValue { get; set; }
    public decimal? FromQtyCf { get; set; }
    public int? ToPortfolioId { get; set; }
    public decimal? ToQtyBf { get; set; }
    public decimal? TransferInValue { get; set; }
    public decimal? OfferPrice { get; set; }
    public decimal? TransferInQty { get; set; }
    public decimal? ToQtyCf { get; set; }
    public string? Status { get; set; }
    public int? ReversalId { get; set; }
    public string? Comments { get; set; }
    public string? VoucherNo { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? CapturedBy { get; set; }
    public string? ApprovedBy { get; set; }
    public int? MoveToIdPortfolioContributor { get; set; }
    
}
