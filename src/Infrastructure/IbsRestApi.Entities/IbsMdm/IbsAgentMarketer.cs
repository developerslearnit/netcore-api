namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsAgentMarketer
{
    public int IdAgentMarketer { get; set; }
    public string? AgentCode { get; set; }
    public string? AgentName { get; set; }
    public string? Address01 { get; set; }
    public string? Address02 { get; set; }
    public string? IdState { get; set; }
    public string? Email { get; set; }
    public string? MobileNumber { get; set; }
    public decimal? ComisionRate { get; set; }
    public string? IdBank { get; set; }
    public string? AccountNo { get; set; }
    public string? BankAccountName { get; set; }
    public string? BankBranchName { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public DateTime? ContractDate { get; set; }
    public DateTime? TerminalDate { get; set; }
}
