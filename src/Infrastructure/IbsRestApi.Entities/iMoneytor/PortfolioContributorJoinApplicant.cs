namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioContributorJoinApplicant
{
    public int IdPortfolioContributorJoinApplicant { get; set; }
    public int IdPortfolioContributor { get; set; }
    public string? Title { get; set; }
    public string? Gender { get; set; }
    public string? SurName { get; set; }
    public string? MiddleName { get; set; }
    public string? FirstName { get; set; }
    public string? IdNationailty { get; set; }
    public string? MaritalStatus { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Address01 { get; set; }
    public string? Address02 { get; set; }
    public string? IdState { get; set; }
    public string? MotherMaidenName { get; set; }
    public string? MobileNo { get; set; }
    public string? Telephone { get; set; }
    public string? Email { get; set; }
    public string? IdIdentifyWith { get; set; }
    public string? OtherForIdentifyWith { get; set; }
    public DateTime? IssueDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? PassportNumber { get; set; }
    public string? PlaceOfIssue { get; set; }
    public string? EmploymentType { get; set; }
    public string? OtherEmployerType { get; set; }
    public string? Occupation { get; set; }
    public int? IdOccupation { get; set; }
    public string? BusinessName { get; set; }
    public string? BusAddress01 { get; set; }
    public string? BusAddress02 { get; set; }
    public string? IdSourceOfFund { get; set; }
    public string? SortCode { get; set; }
}
