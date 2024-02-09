namespace IbsRestApi.Application.Portfolios;

public class PublicPortfolioViewModel
{
    public int portfolioId { get; set; }
    public string portfolioName { get; set; }
    public string portfolioDescription { get; set; }
    public string currencyId { get; set; }
    public bool unitBased { get; set; }
    public bool stableNAV { get; set; }
    public string iconUrl { get; set; }
    public string ProductType { get; set; }
    //
    public string borrowTypeId { get; set; } = string.Empty; //ID_BorrowType
    public decimal OfferPrice { get; set; }
    public decimal minSubAmount { get; set; }
}

public class PublicPortfolioMinViewModel
{
    public int portfolioId { get; set; }
    public string portfolioName { get; set; }
    public string portfolioDescription { get; set; }
    public string currencyId { get; set; }
    public bool unitBased { get; set; }
    public decimal? minSubAmount { get; set; }
    public string ProductType { get; set; }
}

public class PortfolioBankAccount
{
    public int portfolioId { get; set; }
    public string bankCode { get; set; }
    public string accountNumber { get; set; }
}
