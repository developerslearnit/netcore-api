namespace IbsRestApi.Entities.iMoneytor;

public partial class MoneyDetail
{
    public int IdMoneyDetail { get; set; }
    public int IdMoneyMaster { get; set; }
    public string? IdBranch { get; set; }
    public int? IdRequisitionMaster { get; set; }
    public int? IdReceiptMaster { get; set; }
    public DateTime? RequisitionDate { get; set; }
    public string? DetailsOfPayment { get; set; }
    public decimal? ExRate { get; set; }
    public decimal? ForexAmount { get; set; }
    public decimal? Amount { get; set; }
    public string? IdSubCategory { get; set; }
    public string? GlactNo { get; set; }
    public string? IdProductLine { get; set; }
    public byte? Posted { get; set; }
    public byte? Reversed { get; set; }
    public string? IdLocation { get; set; }
    public string? IdApplication { get; set; }
    public string? CustomerCode { get; set; }
    public string? SalesAgentCode { get; set; }
    public int? Ucid { get; set; }
    public int? Usid { get; set; }
    public int? Ueid { get; set; }
    public int? Upid { get; set; }
    public int? Uqid { get; set; }
    public string? Acode01 { get; set; }
    public string? Acode02 { get; set; }
    public string? Acode03 { get; set; }
    public string? Acode04 { get; set; }
    public string? Acode05 { get; set; }
    public bool? ApplyVat { get; set; }
    public bool? ApplywTax { get; set; }
    public bool? PayChargesDirect { get; set; }
}
