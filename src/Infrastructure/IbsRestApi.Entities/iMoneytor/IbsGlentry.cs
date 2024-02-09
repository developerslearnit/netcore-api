namespace IbsRestApi.Entities.iMoneytor;

public partial class IbsGlentry
{
    public int IdGlentry { get; set; }
    public string? IdBranch { get; set; }
    public string? IdProductLine { get; set; }
    public string? IdLocation { get; set; }
    public string? IdApplication { get; set; }
    public string? VoucherNo { get; set; }
    public DateTime? ValueDate { get; set; }
    public string? AccountNo { get; set; }
    public string? Narration { get; set; }
    public decimal? Amount { get; set; }
    public string? PostPeriod { get; set; }
    public DateTime? TransactionDate { get; set; }
    public string? CustomerCode { get; set; }
    public string? SalesAgentCode { get; set; }
    public DateTime? GlpostDate { get; set; }
    public int? IdJobMaster { get; set; }
    public decimal? ForexAmount { get; set; }
    public string? IdCurrency { get; set; }
    public string? Acode01 { get; set; }
    public string? Acode02 { get; set; }
    public string? Acode03 { get; set; }
    public string? Acode04 { get; set; }
    public string? Acode05 { get; set; }
    public int? Ucid { get; set; }
    public int? Usid { get; set; }
    public int? Ueid { get; set; }
    public long? Utid { get; set; }
    public int? Upid { get; set; }
    public int? Uqid { get; set; }
    public string? Id2Link { get; set; }
    public string? VjNumber { get; set; }
    public bool? AffectBank { get; set; }
    public string? Acode06 { get; set; }
    public string? Acode07 { get; set; }
    public string? Acode08 { get; set; }
    public string? Acode09 { get; set; }
    public string? Acode10 { get; set; }
    public string? PostDay { get; set; }
    public string? PostWeek { get; set; }
    public decimal? QtyUnit { get; set; }
    public string? ChequeNo { get; set; }
    public string? PayeePayer { get; set; }
    public bool? Cleared { get; set; }
    public string? ReconComments { get; set; }
    public DateTime? StatementDate { get; set; }
    public int? IdMatchMaster { get; set; }
    public int? IdBankStatement { get; set; }
    public int? IdManyToMany { get; set; }
}
