namespace IbsRestApi.Application.IMoneytor;

public class ClientOwnedPortfolios
{
    public int IdPortfolioContributor { get; set; }

    public int ucid { get; set; }

    public int IdPortfolio { get; set; }

    public string portfolioName { get; set; }

    public bool unitBased { get; set; }

    public bool stableNav { get; set; }

    public decimal InvestmentAmount { get; set; }

    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

    public string FormattedTransactionDate { get { return this.TransactionDate.ToString("dd/MM/yyyy"); } }

    public string FormattedAmount { get { return this.InvestmentAmount.ToString("#,##.00"); } }


}
