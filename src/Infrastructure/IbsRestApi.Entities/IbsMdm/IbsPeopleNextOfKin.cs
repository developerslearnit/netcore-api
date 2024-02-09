namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsPeopleNextOfKin
{
    public int IdNextOfKin { get; set; }
    public int? Ucid { get; set; }
    public string? Title { get; set; }
    public string? FirstName { get; set; }
    public string? OtherNames { get; set; }
    public string? LastName { get; set; }
    public string? Address01 { get; set; }
    public string? Address02 { get; set; }
    public string? City { get; set; }
    public string? IdState { get; set; }
    public string? IdCountry { get; set; }
    public string? Gender { get; set; }
    public DateTime? Dob { get; set; }
    public string? MobilePhone { get; set; }
    public string? Email { get; set; }
    public int? IdRelationShip { get; set; }

    public virtual IbsPerson? Uc { get; set; }
}
