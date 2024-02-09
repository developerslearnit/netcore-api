namespace IbsRestApi.Entities.iMoneytor;

public partial class PortoflioCompliance
{
    public int IdPortofolioCompliance { get; set; }
    public int? IdPortfolio { get; set; }
    public string? IdInvestmentType { get; set; }
    public decimal? InvPercent { get; set; }
    public decimal? MaxInvPercent { get; set; }
    public decimal? AddOrSubtract { get; set; }
    public decimal? MinInvPercent { get; set; }
    
}
