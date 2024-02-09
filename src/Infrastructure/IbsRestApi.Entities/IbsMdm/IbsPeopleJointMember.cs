namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsPeopleJointMember
{
    public int IdJointMember { get; set; }
    public int? Ucid { get; set; }
    public string? Title { get; set; }
    public string? FirstName { get; set; }
    public string? OtherNames { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public bool? CopyMeMails { get; set; }
    public string? MobilePhone { get; set; }
    public string? Address01 { get; set; }
    public string? Address02 { get; set; }
    public string? City { get; set; }
    public string? IdCountry { get; set; }
    public string? IdState { get; set; }
    public string? PostalAddress { get; set; }
    public string? PostalAddress02 { get; set; }
    public string? PostalCity { get; set; }
    public string? PostalIdCountry { get; set; }
    public string? PostalIdState { get; set; }
    public string? Gender { get; set; }
    public DateTime? Dob { get; set; }
    public string? MaritalStatus { get; set; }
    public string? MotherMaidenName { get; set; }
    public string? Nationality { get; set; }
    public string? ResidentPermitNo { get; set; }
    public string? IdStateOfOrigin { get; set; }
    public string? IdIdentifyWith { get; set; }
    public string? Idnumber { get; set; }
    public DateTime? IdissueDate { get; set; }
    public DateTime? IdexpiryDate { get; set; }
    public int? IdIdplaceOfIssue { get; set; }
    public string? IdentifiedBy { get; set; }
    public int? IdOccupation { get; set; }
    public string? EmploymentType { get; set; }
    public string? EmployerCode { get; set; }
    public string? EmployerAddress { get; set; }
    public string? IdReligion { get; set; }
    public string? Bvn { get; set; }

    public virtual IbsPerson? Uc { get; set; }
}
