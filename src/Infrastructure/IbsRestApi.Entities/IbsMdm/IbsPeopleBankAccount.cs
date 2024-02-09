namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsPeopleBankAccount
{
    public int IdBankAccount { get; set; }
    public int? Ucid { get; set; }
    public string? IdBank { get; set; }
    public string? AccountNumber { get; set; }
    public string? AccountName { get; set; }
    public string? Bvn { get; set; }
    public string? SortCode { get; set; }
    public bool? AccountVerified { get; set; }
    public int? MainAccount { get; set; }

    public virtual IbsPerson? Uc { get; set; }
}
