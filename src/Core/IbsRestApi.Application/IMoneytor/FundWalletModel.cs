namespace IbsRestApi.Application.IMoneytor;

public class FundWalletModel
{
    public decimal amount { get; set; }
    public string currency { get; set; }
    public string transRef { get; set; }
    public int client_unique_ref { get; set; }
}

public class FundWalletResultModel
{
    public float balance { get; set; }
    public string currency { get; set; }
    public string formate_balance { get; set; }
}

public class SubscribeModel
{
    public decimal amount { get; set; }
    public string currency { get; set; }
    public int client_unique_ref { get; set; }
    public int product_id { get; set; }
    public string paymentChannel { get; set; } = "";
    public string productType { get; set; }
}

public class BorrowingSubscribeModel : SubscribeModel
{
    public int tenor { get; set; }
    public string borrowTypeId { get; set; }
    public bool showInterest { get; set; } = false;
}

public class SubscriptionEnqModel
{
    public int client_unique_ref { get; set; }

    public int product_id { get; set; }

    public decimal amount { get; set; }

    public decimal balance { get; set; }
}
