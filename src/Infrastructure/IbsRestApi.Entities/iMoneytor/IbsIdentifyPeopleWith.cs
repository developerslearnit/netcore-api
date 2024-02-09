namespace IbsRestApi.Entities.iMoneytor;

public partial class IbsIdentifyPeopleWith
{
    public string IdIdentifyWith { get; set; } = null!;
    public string? IdentifyWith { get; set; }
    public bool? RequireDates { get; set; }
}
