namespace IbsRestApi.Entities.DmsMoneyBook;

public partial class DocumentServer
{
    public int IdDocumentServer { get; set; }
    public int? IdDocumentType { get; set; }
    public byte[]? DocImage { get; set; }
    public DateTime? CreationDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? CreatedBy { get; set; }
    public string? ModifiedBy { get; set; }
    public string? Status { get; set; }
    public int? IdRequisitionMaster { get; set; }
    public string? SearchKey { get; set; }
    public string? ImageFileName { get; set; }
    public string? ImageExt { get; set; }
    public string? SourceDbName { get; set; }
}
