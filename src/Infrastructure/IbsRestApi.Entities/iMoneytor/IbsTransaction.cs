namespace IbsRestApi.Entities.iMoneytor;

public partial class IbsTransaction
{
    public long Utid { get; set; }
    public int? Ucid { get; set; }
    public int? Usid { get; set; }
    public int? Ueid { get; set; }
    public int? Upid { get; set; }
    public int? Uqid { get; set; }
    public string? IdApplication { get; set; }
    public string? Narration { get; set; }
    public string? IdTransClass { get; set; }
    public decimal? Amount { get; set; }
    public string? CapturedBy { get; set; }
    public DateTime? CaptureDate { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovedDate { get; set; }
    public string? DatabaseName { get; set; }
    public string? TableName { get; set; }
    public string? Status { get; set; }
    public bool? Reversed { get; set; }
    public int? ReversalId { get; set; }
    public string? Id2Link { get; set; }
}
