namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioContributorAgent
{
    public string AgentCode { get; set; } = null!;
    public int IdAgent { get; set; }
    public string? AgentName { get; set; }
    public string? Address01 { get; set; }
    public string? Address02 { get; set; }
    public string? IdState { get; set; }
    public string? Email { get; set; }
    public decimal? ComisionRate { get; set; }
    public string? IdBank { get; set; }
    public string? AccountNo { get; set; }
    public string? BankAccountName { get; set; }
    public string? BankBranchName { get; set; }
    public decimal? FirstTarget { get; set; }
    public decimal? RenewTarget { get; set; }
    public DateTime? ContractDate { get; set; }
    public string? Status { get; set; }
    public DateTime? TerminalDate { get; set; }
    public string? Comments { get; set; }
    
    public string? IdReferedByBranch { get; set; }
}
