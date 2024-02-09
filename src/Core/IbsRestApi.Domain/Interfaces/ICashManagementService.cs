using IbsRestApi.Application.IMoneytor;
using IbsRestApi.Entities.iMoneytor;

namespace IbsRestApi.Domain.Interfaces;

public interface ICashManagementService
{
    Task<IQueryable<PortfolioContributorBasicInformationVewModel>> AllContributorsBasic();
    Task<string> ApproveCashInflowAndOutFlow(string transactionType, int id_portfolioContributorAccount, string id_bankAccount = " ", string chequeNo = "", string paymentType = "", string capturedBy = "");
    IQueryable<WalletModel> FetchClientWalletTransactions(int ucid);
    Task<PortfolioContributorBasicInformationVewModel> FetchContributorsBasicByCurrencyAndUCID(string currency, int ucid);
    Task<PortfolioContributorBasicInformationVewModel> FetchContributorsBasicByIdPortfolioAndUCID(int portfolioId, int ucid, string currency);
    Task<Preference> FetchPreference();
    decimal GetClientCashBalance(int id_portfolioContributor, int idPortfolio_Owner, DateTime endDate, int ID_PortfolioContributorAccount = 0);
    Task<decimal> GetClientCashBalance(string currencyId, int ucid, int portfolioId);
    IQueryable<ClientWalletModel> GetClientWalletTransactions(int ucid);
    float GetOfferPriceAsAt(int portfolioId, DateTime endDate, decimal price);
    Task<bool> GetPreviousTransactionReference(string transRef);
    Task<bool> InserIntoPortfoliContributorAccount(string productnamee, decimal amount, string id_bankAccount, string customerName, string id_currency, int id_portfolioContributor, string id_cashMgtAccount, int portfolioId, string capturedBy, decimal unitValue, string application = "API");
    Task<bool> MoveMoneyToCashAccount(string productnamee, decimal amount, string id_bankAccount, string customerName, string id_currency, int id_portfolioContributor, string id_cashMgtAccount, int portfolioId, string caturedBy, decimal unitValue);
    void WalletDepositOrWithdraw(int UCID, string ID_Currency, decimal Amount, string ID_BankAccount, string ID_CashMgtAccount, string TransUniqueRefNo, string DepositOrWithdraw = "D");
    Task<bool> WithdrawFromCashAccount(decimal amount, string id_bankAccount, string customerName, string id_currency, int id_portfolioContributor, string id_cashMgtAccount, string withdrawBy);
}
