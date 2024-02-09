namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioContributor
{
    public PortfolioContributor()
    {
        PortfolioContributorAccounts = new HashSet<PortfolioContributorAccount>();
    }

    public int IdPortfolioContributor { get; set; }
    public string? AccountCode { get; set; }
    public string? FullName { get; set; }
    public string? ContactPerson { get; set; }
    public string? Address01 { get; set; }
    public string? Address02 { get; set; }
    public string? IdState { get; set; }
    public string? IdCountry { get; set; }
    public string? Telephone { get; set; }
    public string? MobileNo { get; set; }
    public string? Email { get; set; }
    public int? IdOccupation { get; set; }
    public DateTime? DateOpened { get; set; }
    public DateTime? DateClosed { get; set; }
    public string? Title { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? IdNationailty { get; set; }
    public string? BusAddress01 { get; set; }
    public string? BusAddress02 { get; set; }
    public string? IdBusState { get; set; }
    public string? NextOfKin { get; set; }
    public string? NextOfKinAddress { get; set; }
    public bool? ReInvestDividend { get; set; }
    public decimal? NoOfUnits { get; set; }
    /// <summary>
    /// Newspaper|Friend|Internet|TV|BillBoard
    /// </summary>
    public string? HearedFrom { get; set; }
    public string? IdBank { get; set; }
    public string? AccountNo { get; set; }
    public string? BankAccountName { get; set; }
    public string? BankBranchName { get; set; }
    public decimal? InitalAmount { get; set; }
    public string? AgentCode { get; set; }
    public string? Comments { get; set; }
    public string? Status { get; set; }
    public bool? WebAccess { get; set; }
    public string? PinNo { get; set; }
    public string? WebPassword { get; set; }
    public string? PaymentMethod { get; set; }
    public string? City { get; set; }
    public string? ChildSurName { get; set; }
    public string? ChildOtherNames { get; set; }
    public string? JointSurName { get; set; }
    public string? JointOtherNames { get; set; }
    public bool? WaiveCertificate { get; set; }
    public string? IdReferedByBranch { get; set; }
    public string? AgentName { get; set; }
    public string? Rcnumber { get; set; }
    public string? EmployeeNo { get; set; }
    public DateTime? EmploymentDate { get; set; }
    public string? JobTitle { get; set; }
    public string? MaritalStatus { get; set; }
    public string? BusinessName { get; set; }
    public string? BusTelephone { get; set; }
    public decimal? AnnualIncome { get; set; }
    public string? NameOfSpouse { get; set; }
    public string? NextofKinTelephone { get; set; }
    public string? AlternateEmail { get; set; }
    public int? CorporateClient { get; set; }
    public DateTime? LastLoginDate { get; set; }
    public string? SubscriptionMethod { get; set; }
    public DateTime? AutoSubscribBeginDate { get; set; }
    public string? NextOfKinEmail { get; set; }
    public int? IdKinRelationship { get; set; }
    public decimal? AutoSubAmount { get; set; }
    public string? Bvn { get; set; }
    public string? IdSourceOfFund { get; set; }
    public string? IdIdentifyWith { get; set; }
    public DateTime? IssueDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public DateTime? RcregisterDate { get; set; }
    public int? IdPortfolioContributorType { get; set; }
    public string? SensitivityLevel { get; set; }
    public int? IdRiskLevel { get; set; }
    public string? SponsorTitle { get; set; }
    public string? SponsorSurname { get; set; }
    public string? SponsorOtherName { get; set; }
    public string? ChildTitle { get; set; }
    public string? JointTitle { get; set; }
    public string? CapturedBy { get; set; }
    public string? NameOfSignatory { get; set; }
    public string? IdSourceBranch { get; set; }
    public string? ExtReferenceId { get; set; }
    public DateTime? SponsorDateOfBirth { get; set; }
    public int? IdImpPrtContributor { get; set; }
    public int? Ucid { get; set; }
    public string? BorrowCustomerRefCode { get; set; }
    public string? Gender { get; set; }
    public bool? PortfolioClient { get; set; }
    public string? Custom01 { get; set; }
    public string? Custom02 { get; set; }
    public string? Custom03 { get; set; }
    public decimal? Custom04 { get; set; }
    public DateTime? Custom05 { get; set; }
    public string? IdCurrency { get; set; }
    public string? Notification { get; set; }
    public int? IdPortfolio { get; set; }
    public string? SubscriptionCode { get; set; }
    public string? MiddleName { get; set; }
    public string? MotherMaidenName { get; set; }
    public string? PassportNumber { get; set; }
    public string? PlaceOfIssue { get; set; }
    public string? OtherForIdentifyWith { get; set; }
    public string? EmploymentType { get; set; }
    public string? OtherEmployerType { get; set; }
    public string? NextOfKinTitle { get; set; }
    public string? NextOfKinGender { get; set; }
    public string? NextOfKinMiddleName { get; set; }
    public string? NextOfKinFirstName { get; set; }
    public DateTime? NextOfKinDateOfBirth { get; set; }
    public string? NatureOfBusiness { get; set; }
    public string? WebSite { get; set; }
    public string? TaxIdentificationNo { get; set; }
    public string? ChildGender { get; set; }
    public string? ChildMiddleName { get; set; }
    public DateTime? ChildDateOfBirth { get; set; }
    public int? IdChildRelationship { get; set; }
    public string? SortCode { get; set; }

    public virtual PortfolioContributorType? IdPortfolioContributorTypeNavigation { get; set; }
    public virtual ICollection<PortfolioContributorAccount> PortfolioContributorAccounts { get; set; }
}
