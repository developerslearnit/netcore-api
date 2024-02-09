namespace IbsRestApi.Entities.iMoneytor;

public partial class Customer
{
    public int IdCustomer { get; set; }
    public bool? IndividualClient { get; set; }
    public string? CompanyName { get; set; }
    public string? ContactPerson { get; set; }
    public string? OfficeAddress01 { get; set; }
    public string? OfficeAddress02 { get; set; }
    public string? IdState { get; set; }
    public string? OfficeTelephone01 { get; set; }
    public string? OfficeTelephone02 { get; set; }
    public string? FaxNumber { get; set; }
    public string? GsmPhone { get; set; }
    public string? EMail { get; set; }
    public string? WebSite { get; set; }
    public string? SendMailsTo { get; set; }
    public DateTime? DateOfIncorporation { get; set; }
    public string? RcNumber { get; set; }
    public int? IdEconomicSector { get; set; }
    public string? PrincipalBusiness { get; set; }
    public string? Auditor1Name { get; set; }
    public string? Auditor2Name { get; set; }
    public int? NoOfBranches { get; set; }
    public string? CompanyType { get; set; }
    public string? LinkedTo { get; set; }
    public string? IdBranch { get; set; }
    public string? FinYearEnd { get; set; }
    public bool? Equity { get; set; }
    public bool? Treasury { get; set; }
    public bool? FixedIncome { get; set; }
    public bool? RealEstate { get; set; }
    public string? Rating { get; set; }
    public string? IdCountry { get; set; }
    public string? CustCode { get; set; }
    
    public int? QvCustomerId { get; set; }
    public int? Ucid { get; set; }
    public string? BeneficiaryBank { get; set; }
    public string? SortCode { get; set; }
    public string? AccountNumber { get; set; }
    public string? SwiftBic { get; set; }
    public string? Iban { get; set; }
    public string? AccountName { get; set; }
}
