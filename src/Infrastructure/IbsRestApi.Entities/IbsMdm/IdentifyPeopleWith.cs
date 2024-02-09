namespace IbsRestApi.Entities.IbsMdm;

public partial class IdentifyPeopleWith
{
    public string IdIdentifyWith { get; set; } = null!;
    public string? IdentifyWith { get; set; }
    public bool? RequireDates { get; set; }
}
