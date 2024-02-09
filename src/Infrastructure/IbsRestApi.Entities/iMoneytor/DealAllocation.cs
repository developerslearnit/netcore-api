namespace IbsRestApi.Entities.iMoneytor;

public partial class DealAllocation
{
    public int IdDealAllocation { get; set; }
    public int? IdDealMaster { get; set; }
    public int? IdPortfolio { get; set; }
    public decimal? Amount { get; set; }
    public DateTime ValueDate { get; set; }
    public decimal? CommissionAmount { get; set; }
    
}
