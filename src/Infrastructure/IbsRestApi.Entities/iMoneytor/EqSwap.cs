namespace IbsRestApi.Entities.iMoneytor;

public partial class EqSwap
{
    public int SwapId { get; set; }
    public int? ShareId { get; set; }
    public DateTime? TransferDate { get; set; }
    public int? TransferQty { get; set; }
    public decimal? TransferCost { get; set; }
    public int? FromPortfolio { get; set; }
    public int? FromQtyBf { get; set; }
    public decimal? FromCostBf { get; set; }
    public int? FromQtyCf { get; set; }
    public decimal? FromCostCf { get; set; }
    public int? ToPortfolio { get; set; }
    public int? ToQtyBf { get; set; }
    public decimal? ToCostBf { get; set; }
    public int? ToQtyCf { get; set; }
    public decimal? ToCostCf { get; set; }
    public string? VoucherNo { get; set; }
    public int? ReversalId { get; set; }
    public string? Narration { get; set; }
    public DateTime? SettlementDate { get; set; }
    public string? FromCsCsId { get; set; }
    public string? FromInvActNo { get; set; }
    public string? ToCsCsId { get; set; }
    public string? ToInvActNo { get; set; }
    public decimal? SellBrokerRate { get; set; }
    public decimal? SellBrokerComision { get; set; }
    public decimal? BuylBrokerRate { get; set; }
    public decimal? BuyBrokerComision { get; set; }
    public decimal? TransferPrice { get; set; }
    public decimal? Consideration { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlPostPeriod { get; set; }
    
}
