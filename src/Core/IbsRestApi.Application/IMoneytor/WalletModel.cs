namespace IbsRestApi.Application.IMoneytor;

public class WalletModel
{
    public decimal amount { get; set; }
    public DateTime transactionDate { get; set; }
    public string narration { get; set; }
    public string currency { get; set; }
}

public class ClientWalletModel
{
    public decimal amount { get; set; }
    public string currency { get; set; }
}
