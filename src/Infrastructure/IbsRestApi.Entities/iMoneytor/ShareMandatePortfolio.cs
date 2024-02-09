namespace IbsRestApi.Entities.iMoneytor;

public partial class ShareMandatePortfolio
{
    public int IdShareMandatePortfolio { get; set; }
    public int? IdShareMandateDetail { get; set; }
    public int? PortfolioId { get; set; }
    public int? PortfolioGroupId { get; set; }
    public decimal? AllocatedQty { get; set; }
    public decimal? AllocatedCost { get; set; }
    public decimal? TakenQty { get; set; }
    public decimal? TakenCost { get; set; }
    
}
