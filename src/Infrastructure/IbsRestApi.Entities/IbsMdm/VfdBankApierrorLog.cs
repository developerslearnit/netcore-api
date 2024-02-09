namespace IbsRestApi.Entities.IbsMdm;

public partial class VfdBankApierrorLog
{
    public int ErrorLogId { get; set; }
    public string ErrorCode { get; set; } = null!;
    public string ErrorMessage { get; set; } = null!;
    public string ApiendPoint { get; set; } = null!;
    public DateTime ErrorDate { get; set; }
}
