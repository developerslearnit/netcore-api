namespace IbsRestApi.Entities.iMoneytor;

public partial class IEventNotification
{
    public int IdEventNotification { get; set; }
    public int? IdTransactionProcess { get; set; }
    public int? ShareId { get; set; }
    public int? IdDealMaster { get; set; }
    public int? IdLoanMaster { get; set; }
    public string? SecurityCode { get; set; }
    public string? SecurityName { get; set; }
    public string? SecurityAddress { get; set; }
    public string? EventType { get; set; }
    public DateTime? DeclarationDate { get; set; }
    public DateTime? ExDate { get; set; }
    public DateTime? RecordDate { get; set; }
    public DateTime? PaymentDate { get; set; }
    public decimal? Rate { get; set; }
    public DateTime? ResponseDate { get; set; }
    public decimal? RedemptionPrice { get; set; }
    public DateTime? ProxyDate { get; set; }
    public DateTime? MeetingDate { get; set; }
    public string? MeetingTimeVenue { get; set; }
    public string? FractionMode { get; set; }
    public int? Xratio { get; set; }
    public int? Yratio { get; set; }
    public decimal? SubscriptionPrice { get; set; }
    public DateTime? ConversionDate { get; set; }
    public string? Narrative { get; set; }
    public string? IntermediateSecurity { get; set; }
    public string? InterSecName { get; set; }
    public string? ResultantSecurity { get; set; }
    public string? ResSecName { get; set; }
    public string? LegalRestrictions { get; set; }
    public string? Status { get; set; }
    public DateTime? SettlementDate { get; set; }
    
}
