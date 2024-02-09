namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsPeopleAccountSignatory
{
    public int IdAccountSignatory { get; set; }
    public int? Ucid { get; set; }
    public string? Title { get; set; }
    public string? FirstName { get; set; }
    public string? OtherName { get; set; }
    public string? LastName { get; set; }
    public string? MotherMaidenName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Gender { get; set; }
    public string? MaritalStatus { get; set; }
    public string? Nationalty { get; set; }
    public int? IdPlaceOfBirth { get; set; }
    public string? IdStateOfOrigin { get; set; }
    public string? ResidensyStatus { get; set; }
    public string? ResidentPermit { get; set; }
    public DateTime? PermitIssueDate { get; set; }
    public DateTime? PermitExpiryDate { get; set; }
    public string? OtherCountryOfTaxResidence { get; set; }
    public string? IdIdentifyWith { get; set; }
    public string? Idnumber { get; set; }
    public DateTime? IssueDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? Bvn { get; set; }
    public int? IdOccupation { get; set; }
    public string? JobTitle { get; set; }
    public string? Address01 { get; set; }
    public string? Address02 { get; set; }
    public string? City { get; set; }
    public string? IdState { get; set; }
    public string? IdLga { get; set; }
    public string? Email { get; set; }
    public string? SignatoryClass { get; set; }
    public string? MobilePhone01 { get; set; }
    public string? MobilePhone02 { get; set; }
    public byte[]? SignatureScan { get; set; }
    public DateTime? CaptureDate { get; set; }
    public bool? Bvnverified { get; set; }

    public virtual IbsPerson? Uc { get; set; }
}
