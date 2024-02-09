namespace IbsRestApi.Entities.iMoneytor;

public partial class IEventConfirmation
{
    public int IdEventConfirmation { get; set; }
    public int? IdTransactionProcess { get; set; }
    public int? ShareId { get; set; }
    public int? IdDealMaster { get; set; }
    public int? IdLoanMaster { get; set; }
    public string? SecurityCode { get; set; }
    public string? SecurityName { get; set; }
    public string? EventType { get; set; }
    public DateTime? DeclarationDate { get; set; }
    public DateTime? ExDate { get; set; }
    public DateTime? RecordDate { get; set; }
    public string? ResultantSecurity { get; set; }
    public string? ResultantSecName { get; set; }
    public string? SkfAccountCode { get; set; }
    public string? SkfAccountCodeName { get; set; }
    public DateTime? ActualPayDate { get; set; }
    public decimal? EntitledPosition { get; set; }
    public decimal? Amount { get; set; }
    public string? SortCode { get; set; }
    public string? AccountNumber { get; set; }
    public int? QuantityReceived { get; set; }
    public decimal? CashInLieu { get; set; }
    public string? Narrative { get; set; }
    public string? LegalRestrictions { get; set; }
    public string? Status { get; set; }
    public int? CallBackId { get; set; }
    public string? Usedfor { get; set; }
    public DateTime? SettlementDate { get; set; }
    
}
