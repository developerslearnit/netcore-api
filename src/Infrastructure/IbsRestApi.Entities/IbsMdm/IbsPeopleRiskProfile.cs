namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsPeopleRiskProfile
{
    public int IdIbsPeopleRiskProfile { get; set; }
    public int? Ucid { get; set; }
    public DateTime? ProfileDate { get; set; }
    public string? ProfileBasis { get; set; }
    public string? IdKycRiskProfile { get; set; }
    public string? Status { get; set; }
    public DateTime? ApprovedDate { get; set; }
    public string? ApprovedBy { get; set; }

    public virtual IbsPerson? Uc { get; set; }
}
