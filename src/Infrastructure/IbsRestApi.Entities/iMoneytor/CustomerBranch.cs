namespace IbsRestApi.Entities.iMoneytor;

public partial class CustomerBranch
{
    public int IdCustomerBranch { get; set; }
    public int? IdCustomer { get; set; }
    public string? Name { get; set; }
    public string? ContactPerson { get; set; }
    public string? Address01 { get; set; }
    public string? Address02 { get; set; }
    public string? IdState { get; set; }
    public string? Telephones { get; set; }
    public string? EMail { get; set; }
    public string? BeneficiaryBank { get; set; }
    public string? SortCode { get; set; }
    public string? AccountNumber { get; set; }
    public string? SwiftBic { get; set; }
    public string? Iban { get; set; }
    public string? AccountName { get; set; }
}
