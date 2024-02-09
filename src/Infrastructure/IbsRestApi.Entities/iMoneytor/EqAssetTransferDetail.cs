namespace IbsRestApi.Entities.iMoneytor;

public partial class EqAssetTransferDetail
{
    public int IdEqAssetTransferDetail { get; set; }
    public int? IdEqAssetTransfer { get; set; }
    public int? ShareId { get; set; }
    public decimal? QtyUnit { get; set; }
    public decimal? MarketValue { get; set; }
    public decimal? AssetValue { get; set; }
    public decimal? SellStampDuty { get; set; }
    public decimal? SellCommission { get; set; }
    public decimal? SellVat { get; set; }
    public decimal? SellSecFees { get; set; }
    public decimal? SellNseCscsfees { get; set; }
    public decimal? SellOtherFees { get; set; }
    public decimal? SellAdjustment { get; set; }
    public decimal? BuyStampDuty { get; set; }
    public decimal? BuyCommission { get; set; }
    public decimal? BuyVat { get; set; }
    public decimal? BuySecFees { get; set; }
    public decimal? BuyNseCscsfees { get; set; }
    public decimal? BuyOtherFees { get; set; }
    public decimal? BuyAdjustment { get; set; }
    public decimal? TransactionCost { get; set; }
    public int? UniqueId { get; set; }
    
}
