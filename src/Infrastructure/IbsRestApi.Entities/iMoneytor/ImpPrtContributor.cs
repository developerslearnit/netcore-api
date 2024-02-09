namespace IbsRestApi.Entities.iMoneytor;

public partial class ImpPrtContributor
{
    public int IdImpPrtContributor { get; set; }
    public string? AccountCode { get; set; }
    public string? Title { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public string? FullName { get; set; }
    public string? Address01 { get; set; }
    public string? Address02 { get; set; }
    public string? City { get; set; }
    public string? IdState { get; set; }
    public string? Telephone { get; set; }
    public string? MobileNo { get; set; }
    public string? Email { get; set; }
    public string? NextOfKin { get; set; }
    public string? ChildSurName { get; set; }
    public string? ChildOtherNames { get; set; }
    public string? JointSurName { get; set; }
    public string? JointOtherNames { get; set; }
    public string? IdBank { get; set; }
    public string? AccountNo { get; set; }
    public string? Rcnumber { get; set; }
    public bool? WaiveCertificate { get; set; }
    public string? IdReferedByBranch { get; set; }
    public string? AgentCode { get; set; }
    public string? AgentName { get; set; }
    public DateTime? DateOpened { get; set; }
    public decimal? NoOfUnits { get; set; }
    public decimal? InitalAmount { get; set; }
    public string? Status { get; set; }
    public bool? CompleteOnImport { get; set; }
    public string? CapturedBy { get; set; }
    public DateTime? DateCaptured { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? DateApproved { get; set; }
    public string? Comments { get; set; }
    
    public string? Bvn { get; set; }
    public string? IdSourceOfFund { get; set; }
    public string? IdIdentifyWith { get; set; }
    public DateTime? IssueDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public DateTime? RcregisterDate { get; set; }
    public int? IdPortfolioContributorType { get; set; }
    public int? IdRiskLevel { get; set; }
    public string? SponsorTitle { get; set; }
    public string? SponsorSurname { get; set; }
    public string? SponsorOtherName { get; set; }
    public string? ChildTitle { get; set; }
    public string? JointTitle { get; set; }
    public string? NameOfSignatory { get; set; }
    public string? IdSourceBranch { get; set; }
    public string? ExtReferenceId { get; set; }
    public DateTime? SponsorDateOfBirth { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public DateTime? MinorDateOfBirth { get; set; }
    public string? IdNumber { get; set; }
    public string? ImportBy { get; set; }
    public string? OfferType { get; set; }
    public string? IncomeDistribute { get; set; }
    public bool? ReInvestDividend { get; set; }
    public int? Ucid { get; set; }
    public string? IdCurrency { get; set; }
}
