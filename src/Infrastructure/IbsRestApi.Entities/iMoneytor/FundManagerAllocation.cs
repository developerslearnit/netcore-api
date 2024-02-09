namespace IbsRestApi.Entities.iMoneytor;

public partial class FundManagerAllocation
{
    public int IdFundManagerAllocation { get; set; }
    public int? IdFundManagerAccount { get; set; }
    public string? BrokerId { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? ValueDate { get; set; }
    public decimal? Amount { get; set; }
    
}
