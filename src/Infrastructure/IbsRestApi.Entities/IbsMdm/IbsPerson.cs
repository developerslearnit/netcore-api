namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsPerson
{
    public IbsPerson()
    {
        CustomerRiskProfiles = new HashSet<CustomerRiskProfile>();
        IbsPeopleAccountSignatories = new HashSet<IbsPeopleAccountSignatory>();
        IbsPeopleAssociationMembers = new HashSet<IbsPeopleAssociationMember>();
        IbsPeopleBankAccounts = new HashSet<IbsPeopleBankAccount>();
        IbsPeopleContactPeople = new HashSet<IbsPeopleContactPerson>();
        IbsPeopleDirectors = new HashSet<IbsPeopleDirector>();
        IbsPeopleJointMembers = new HashSet<IbsPeopleJointMember>();
        IbsPeopleLiens = new HashSet<IbsPeopleLien>();
        IbsPeopleNextOfKins = new HashSet<IbsPeopleNextOfKin>();
        IbsPeopleRiskProfiles = new HashSet<IbsPeopleRiskProfile>();
    }

    public int Ucid { get; set; }
    public string? LastName { get; set; }
    public string? OtherNames { get; set; }
    public bool? Company { get; set; }
    public string? Rcnumber { get; set; }
    public string? MobilePhone { get; set; }
    public string? OtherPhones { get; set; }
    public string? FaxNumber { get; set; }
    public string? Email { get; set; }
    public string? IdCountry { get; set; }
    public string? Address01 { get; set; }
    public string? Address02 { get; set; }
    public string? City { get; set; }
    public string? IdState { get; set; }
    public string? Gender { get; set; }
    public DateTime? Dob { get; set; }
    public bool? Customer { get; set; }
    public bool? Supplier { get; set; }
    public bool? Employee { get; set; }
    public string? IdApplication { get; set; }
    public string? IdIdentifyWith { get; set; }
    public string? Idnumber { get; set; }
    public string? IdentifiedBy { get; set; }
    public DateTime? CreationDate { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public string? DatabaseName { get; set; }
    public string? TableName { get; set; }
    public string? PccNo { get; set; }
    public string? FirstName { get; set; }
    public string? MaidenName { get; set; }
    public string? MotherMaidenName { get; set; }
    public string? Title { get; set; }
    public string? Bvn { get; set; }
    public string? Nim { get; set; }
    public string? MaritalStatus { get; set; }
    public bool? PhysicallyChallenged { get; set; }
    public string? Nationality { get; set; }
    /// <summary>
    /// Individual (IND)
    /// Minor (MIN)
    /// Corporate (CRP)
    /// Joint (JNT)
    /// Association (ASS)
    /// </summary>
    public string? IdCustomerType { get; set; }
    public int? IdNatureOfBusiness { get; set; }
    public string? IdSourceOfFunds { get; set; }
    public string? Tin { get; set; }
    public string? Vatno { get; set; }
    public int? CountInJoint { get; set; }
    public DateTime? IdissueDate { get; set; }
    public DateTime? IdexpiryDate { get; set; }
    public int? IdIdplaceOfIssue { get; set; }
    public string? IdStateOfOrigin { get; set; }
    public bool? ResidentAddressVerified { get; set; }
    public string? WebSite { get; set; }
    public string? Twiter { get; set; }
    public string? FaceBook { get; set; }
    public string? LinkedIn { get; set; }
    public string? Instagram { get; set; }
    public string? PostalAddress1 { get; set; }
    public string? PostalAddress2 { get; set; }
    public string? PostalCity { get; set; }
    public string? IdPostalCountry { get; set; }
    public string? IdPostalState { get; set; }
    public string? ChildLastName { get; set; }
    public string? ChildFirstName { get; set; }
    public string? ChildOtherName { get; set; }
    public DateTime? ChildDob { get; set; }
    public int? ChildIdRelationShip { get; set; }
    public string? ChildGender { get; set; }
    public string? ChildTitle { get; set; }
    public bool? KycPoliticallyExposed { get; set; }
    public bool? KycFinanciallyExposed { get; set; }
    public bool? KycComplete { get; set; }
    public string? KycVerifiedby { get; set; }
    public DateTime? KycVerifiedDate { get; set; }
    public string? IdRiskProfile { get; set; }
    public DateTime? AniversaryDate { get; set; }
    public string? Cscsno { get; set; }
    public string? InHouseNo { get; set; }
    public string? Chnumber { get; set; }
    public string? EmployerCode { get; set; }
    public int? IdAgent { get; set; }
    public string? HearedFrom { get; set; }
    public int? IdPlaceOfBirth { get; set; }
    public int? IdOccupation { get; set; }
    public int? IdIncomeRange { get; set; }
    public bool? OperatingAtHome { get; set; }
    public bool? OperatingAbroad { get; set; }
    public DateTime? DateBizCommenced { get; set; }
    public string? ScumlregNo { get; set; }
    public bool? Importer { get; set; }
    public bool? Exporter { get; set; }
    public int? NoOfEmployees { get; set; }
    public string? CoporateType { get; set; }
    public string? IdResLga { get; set; }
    public string? IdPostalLga { get; set; }
    public int? IdEconomicSector { get; set; }
    public int? MandateCombination { get; set; }
    public bool? OnLineAccess { get; set; }
    public bool? EmailNotification { get; set; }
    public bool? StatementNotification { get; set; }
    public bool? Smsnotification { get; set; }
    public string? RiskClass { get; set; }
    public bool? CapturedViaBvn { get; set; }
    public bool? Bvnverified { get; set; }
    public int? IdReligion { get; set; }
    public string? EmploymentType { get; set; }
    public string? EmployerAddress { get; set; }
    public string? ResidentPermit { get; set; }
    public string? IdOriginLga { get; set; }
    public string? JointAccountName { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public int? ParrentUCID { get; set; }

    public virtual ICollection<CustomerRiskProfile> CustomerRiskProfiles { get; set; }
    public virtual ICollection<IbsPeopleAccountSignatory> IbsPeopleAccountSignatories { get; set; }
    public virtual ICollection<IbsPeopleAssociationMember> IbsPeopleAssociationMembers { get; set; }
    public virtual ICollection<IbsPeopleBankAccount> IbsPeopleBankAccounts { get; set; }
    public virtual ICollection<IbsPeopleContactPerson> IbsPeopleContactPeople { get; set; }
    public virtual ICollection<IbsPeopleDirector> IbsPeopleDirectors { get; set; }
    public virtual ICollection<IbsPeopleJointMember> IbsPeopleJointMembers { get; set; }
    public virtual ICollection<IbsPeopleLien> IbsPeopleLiens { get; set; }
    public virtual ICollection<IbsPeopleNextOfKin> IbsPeopleNextOfKins { get; set; }
    public virtual ICollection<IbsPeopleRiskProfile> IbsPeopleRiskProfiles { get; set; }
}
