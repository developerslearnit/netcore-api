namespace IbsRestApi.Entities.iMoneytor;

public partial class IbsInterfaceManager
{
    public string IdIManager { get; set; } = null!;
    public string? Description { get; set; }
    public string? ReversalSpName { get; set; }
    public string? RequisitionSpName { get; set; }
    public string? ReceiptSpName { get; set; }
    public string? DbName { get; set; }
    public string? TblName { get; set; }
    public string? VoucherFieldName { get; set; }
    public string? PrimaryFieldName { get; set; }
    public string? IdApplication { get; set; }
}
