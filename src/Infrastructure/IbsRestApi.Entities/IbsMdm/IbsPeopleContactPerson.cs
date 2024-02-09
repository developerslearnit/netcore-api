namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsPeopleContactPerson
{
    public int IdContactPerson { get; set; }
    public int? Ucid { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Designation { get; set; }
    public string? Email { get; set; }
    public string? PhoneNo { get; set; }

    public virtual IbsPerson? Uc { get; set; }
}
