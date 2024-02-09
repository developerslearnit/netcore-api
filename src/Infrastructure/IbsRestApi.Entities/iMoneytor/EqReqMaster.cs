namespace IbsRestApi.Entities.iMoneytor;

public partial class EqReqMaster
{
    public int IdEqReqMaster { get; set; }
    public int? IdShare { get; set; }
    public int? DepositId { get; set; }
    public int? RightId { get; set; }
    public int? UniqueId { get; set; }
    public DateTime? RequestDate { get; set; }
    public string? Payee { get; set; }
    public string? Being { get; set; }
    public string? RequestType { get; set; }
    public decimal? Amount { get; set; }
    public string? Status { get; set; }
    public string? VoucherNo { get; set; }
    public int? ReversalId { get; set; }
    public DateTime? SettlementDate { get; set; }
    public int? IdShareMandateDetail { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlPostPeriod { get; set; }
    public string? IdBackAccountNo { get; set; }
    public string? CheqNo { get; set; }
    public decimal? ComChgAmount { get; set; }
    
}
