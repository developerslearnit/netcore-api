namespace IbsRestApi.Entities.iMoneytor;

public partial class IbsRequisitionEftdetail
{
    public int IdEftdetails { get; set; }
    public int? IdRequisitionMaster { get; set; }
    public int? IdCustomer { get; set; }
    public string AccountNo { get; set; } = null!;
    public string? SortCode { get; set; }
    public string? AccountType { get; set; }
    public decimal? Amount { get; set; }
    public string? AccountName { get; set; }
    public string? IdBank { get; set; }
    public bool? DoNotSend { get; set; }
    public int? Ucid { get; set; }
    public int? CallBackId { get; set; }
    public string? IdIManager { get; set; }
}
