namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsPeopleAssociationMember
{
    public int IdAssociationMember { get; set; }
    public int? Ucid { get; set; }
    public string? Title { get; set; }
    public string? FirstName { get; set; }
    public string? OtherNames { get; set; }
    public string? LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Bvn { get; set; }
    public string? BankAccountNo { get; set; }

    public virtual IbsPerson? Uc { get; set; }
}
