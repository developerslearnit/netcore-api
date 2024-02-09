namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsPeopleLien
{
    public int IdIbsPeopleLien { get; set; }
    public int? Ucid { get; set; }
    public DateTime? LienDate { get; set; }
    public string? Narration { get; set; }
    public string? CaptureBy { get; set; }
    public DateTime? CaptureDate { get; set; }
    public bool? Released { get; set; }
    public string? ReleasedBy { get; set; }
    public DateTime? ReleaseDate { get; set; }

    public virtual IbsPerson? Uc { get; set; }
}
