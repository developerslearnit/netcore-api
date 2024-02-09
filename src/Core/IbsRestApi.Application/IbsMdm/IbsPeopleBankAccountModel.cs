namespace IbsRestApi.Application.IbsMdm;

public class IbsPeopleBankAccountModel
{
    public int id { get; set; }
    public int client_unique_ref { get; set; }
    public string IdBank { get; set; }
    public string BankCode { get; set; } = "";
    public string BankName { get; set; } = "";
    public string AccountNumber { get; set; }
    public string AccountName { get; set; }
    public string Bvn { get; set; }
}

public class IbsPeopleBankAccountResultModel
{
    public int id { get; set; }
}
