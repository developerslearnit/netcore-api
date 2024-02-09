namespace IbsRestApi.Entities.iMoneytor;

public partial class IbsRequisitionDetail
{
    public int IdRequisitionDetails { get; set; }
    public int? IdRequisitionMaster { get; set; }
    public string? IdBranch { get; set; }
    public DateTime? RequisitionDate { get; set; }
    public string? DetailsOfPayment { get; set; }
    public decimal? ExRate { get; set; }
    public decimal? ForexAmount { get; set; }
    public decimal? Amount { get; set; }
    public string? IdSubCategory { get; set; }
    public string? IdProductLine { get; set; }
    public string? GlactNo { get; set; }
    public DateTime? TransactionDate { get; set; }
    public int? IdCallBack { get; set; }
    public string? IdLocation { get; set; }
    public string? IdIManager { get; set; }
    public string? IdBankAccount { get; set; }
    public string? DbName { get; set; }
    public string? CustomerCode { get; set; }
    public string? SalesAgentCode { get; set; }
    public bool? ApplyVat { get; set; }
    public bool? ApplywTax { get; set; }
    public bool? PayChargesDirect { get; set; }
    public int? Uqid { get; set; }
    public int? Upid { get; set; }
    public string? Acode01 { get; set; }
    public string? Acode02 { get; set; }
    public string? Acode03 { get; set; }
    public string? Acode04 { get; set; }
    public string? Acode05 { get; set; }
    public bool? VatAble { get; set; }
    public bool? WtaxAble { get; set; }
    public string? IdDisbursementType { get; set; }
}
