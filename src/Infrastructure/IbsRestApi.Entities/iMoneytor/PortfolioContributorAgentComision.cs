namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioContributorAgentComision
{
    public int IdPortfolioContributorAgentComision { get; set; }
    public int? IdPortfolioContributionAccount { get; set; }
    public int? IdPortfolioContribution { get; set; }
    public string? AgentCode { get; set; }
    public DateTime? TransactionDate { get; set; }
    public DateTime? ValueDate { get; set; }
    public string? Narration { get; set; }
    public decimal? Amount { get; set; }
    public string? TransactionType { get; set; }
    public string? VoucherNo { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlPostPeriod { get; set; }
    
}
