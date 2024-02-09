namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsPeopleDirector
{
    public int IdDirector { get; set; }
    public int? Ucid { get; set; }
    public string? Title { get; set; }
    public string? FirstName { get; set; }
    public string? OtherNames { get; set; }
    public string? LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Gender { get; set; }
    public string? Email { get; set; }
    public string? IdIdentifyWith { get; set; }
    public string? Idnumber { get; set; }
    public string? Nationalty { get; set; }
    public string? Bvn { get; set; }
    public decimal? HoldingPercent { get; set; }
    public bool? Bvnverified { get; set; }

    public virtual IbsPerson? Uc { get; set; }
}
