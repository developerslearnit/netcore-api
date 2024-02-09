namespace IbsRestApi.Entities.iMoneytor;

public partial class EquityBrokersDreditCredit
{
    public int IdEquityBrokersDreditCredit { get; set; }
    public string? BrokerId { get; set; }
    public int? UniqueId { get; set; }
    public string? MemoType { get; set; }
    public DateTime? IssueDate { get; set; }
    public string? Narration { get; set; }
    public decimal? Amount { get; set; }
    public int? IdEquityBrokersDrCrRequisition { get; set; }
    public string? Status { get; set; }
    public string? IdCurrency { get; set; }
    public int? IdPortfolio { get; set; }
    public int? DepositId { get; set; }
    
}
