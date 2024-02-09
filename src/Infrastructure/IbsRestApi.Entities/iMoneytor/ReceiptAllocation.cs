namespace IbsRestApi.Entities.iMoneytor;

public partial class ReceiptAllocation
{
    public int IdReceiptAllocation { get; set; }
    public int? IdReceipt { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? ValueDate { get; set; }
    public decimal? Amount { get; set; }
    public decimal? Principal { get; set; }
    public decimal? Interest { get; set; }
    public decimal? InterestAdjustment { get; set; }
    public decimal? WithHoldTax { get; set; }
    public decimal? ProfitLoss { get; set; }
    
    public decimal? ExtraInterest { get; set; }
}
