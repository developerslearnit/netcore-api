namespace IbsRestApi.Entities.DmsMoneyBook;

public partial class IbsPeopleKyc
{
    public int IdKyc { get; set; }
    public int? Ucid { get; set; }
    public int? IdKycCheckList { get; set; }
    public bool? Submitted { get; set; }
    public bool? Waived { get; set; }
    public DateTime? ActionDate { get; set; }
    public string? ActionBy { get; set; }
    public bool? Verified { get; set; }
    public string? VerifiedBy { get; set; }
    public DateTime? VerifiedDate { get; set; }
    public byte[]? DocImage { get; set; }
    public string? FileExtension { get; set; }

    public virtual KycChecklist? IdKycCheckListNavigation { get; set; }
}
