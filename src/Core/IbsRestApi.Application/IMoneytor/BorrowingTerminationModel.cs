using System.Text.Json.Serialization;

namespace IbsRestApi.Application.IMoneytor;

public class BorrowingTerminationModel
{
    [JsonPropertyName("dealId")]
    public int DealId { get; set; }

    [JsonPropertyName("client_unique_ref")]
    public int ClientId { get; set; }

    //[JsonPropertyName("withdrawalDate")]
    //public string WithdrawalDate { get; set; }

    [JsonPropertyName("withdrawalType")]
    public string WithdrawalType { get; set; }

    [JsonPropertyName("withdrawalAmount")]
    public decimal withdrawalAmount { get; set; }

}

public class BorrowWithdrawalResponseDetails
{
    [JsonPropertyName("dealId")]
    public int DealId { get; set; }

    [JsonPropertyName("principalBalance")]
    public decimal PrincipalBalance { get; set; }

    [JsonPropertyName("interestBalance")]
    public decimal InterestBalance { get; set; }

    [JsonPropertyName("penaltyAmount")]
    public decimal PenaltyAmount { get; set; }

    [JsonPropertyName("subTotal")]
    public decimal SubTotal { get; set; }

    [JsonPropertyName("withDrawAmount")]
    public decimal WithDrawAmount { get; set; }

    [JsonPropertyName("settleAmount")]
    public decimal TotalAmount { get; set; }


}

public class BorrowTerminateInitialModel
{
    public int DealId { get; set; }
    public int client_unique_ref { get; set; }
    public string ErrorMessage { get; set; } = "";
}

public class BorrowTerminateConfirmModel
{
    public int terminateId { get; set; }
    public int client_unique_ref { get; set; }
}

public class CustomerActiveDealsModel
{
    [JsonPropertyName("dealId")]
    public int DealId { get; set; }
    [JsonPropertyName("portfoioId")]
    public int PortfoioId { get; set; }
    [JsonPropertyName("portfolioName")]
    public string PortfolioName { get; set; }
    [JsonPropertyName("tenor")]
    public int Tenor { get; set; }
    [JsonPropertyName("maturityDate")]
    public string MaturityDate { get; set; }
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }
}

public class BorrowTerminateDetailModel
{
    [JsonPropertyName("terminateId")]
    public int TerminateId { get; set; }

    [JsonPropertyName("dealId")]
    public int DealId { get; set; }

    [JsonPropertyName("principal")]
    public decimal Principal { get; set; }

    [JsonPropertyName("penaltyAmount")]
    public decimal PenaltyAmount { get; set; }

    [JsonPropertyName("interest")]
    public decimal Interest { get; set; }
}