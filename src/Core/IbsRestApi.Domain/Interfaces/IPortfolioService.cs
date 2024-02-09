using IbsRestApi.Application.IMoneytor;
using IbsRestApi.Application.Portfolios;
using IbsRestApi.Entities.iMoneytor;

namespace IbsRestApi.Domain.Interfaces;

public interface IPortfolioService
{
    Task<bool> AddExistingClientOrder(ExistingClientOrderModel model);
    ExistingClientOrder GetExistingClientOrder(string trasactionRef);
    Task<bool> UpdateExistingClientOrder(string trasactionRef);
    bool AddCustomerDebitTransaction(int idPortfolioContributor, DateTime transactionDate, DateTime valueDate, decimal amount, string transactionType, string narration, string currencyId, string comment, string capturedBy);
    Task<int> AddCustomerTransaction(int portfolioId, int idPortfolioContributor, DateTime transactionDate, DateTime valueDate, decimal amount, string transactionType, string narration, string currencyId, string comment, string capturedBy, bool isMutualFund = true, string application = "API");
    Task<decimal> AddRedemptionRequest(int portfolioId, int portfolioContributorId);
    IEnumerable<BorrowingProductViewModel> AllBorrowing();
    Task<List<RedemptionViewModel>> AutoRedemption(int ID_PortfolioContributor, int ID_Portfolio, DateTime SalesDate, decimal GrsQty2Sell, bool RedeemPlusProfit, bool WaivePenalTy);
    void DeleteTempRedemptionRequest(int portfolioId, int customerId);
    IQueryable<BorrowTypeModel> FetchBorrowTypeList();
    Task<List<ClientInvestmentViewModel>> FetchClientInvestments(int UCID);
    IQueryable<ClientOwnedPortfolios> FetchClientOwnedPortfolios();
    IQueryable<TransactionViewModel> FetchClientTransactions(int ucid, int fundId);
    IQueryable<TransactionViewModel> FetchClientTransactionsByUCIDAndFundId(int ucid, int fundId);
    Task<float> FetchCustomerCashBalance(int ucid, int portfolioId, string currency, int portfolioOwnerId, DateTime endDate);
    Task<BorrowingCalculationDetails> FetchFundingTermCalculations(int dealId, string withdrawalType, decimal withDrawAmount);
    Task<List<PortfolioBankAccount>> FetchPortfolioBankAccounts();
    string FetchPortfolioCurrency(int portfolioId);
    Task<PortfolioGroup> FetchPortfolioGroup(int idPortfolioGroup);
    IQueryable<BorrowRateModel> FetchPublicFixedDepositRateGap();
    Task<float> GetBidPriceAsAt(int portfolioId, DateTime endDate, decimal price = 0);
    FixedDepositOutputParam GetGeneric_sp_CalculateInterest(GenericSPForCalculatingInterest model, int productid);
    Task<DateTime> GetLastValuationDate(int portfolioId);
    Task<decimal> GetPortfolioBalance(int portfolioId, int portfolioContributor);
    Task<PortfolioContributor> GetPortfolioContributor(int ucid, string currency);
    int GetUCIDWithAccountCode(string accountCode);
    Task<bool> InsertCustomerBorrowTransaction(int portfolioId, int idPortfolioContributor, DateTime transactionDate, DateTime valueDate, decimal amount, string transactionType, string narration, string currencyId, string comment, string capturedBy, string application = "API");
    bool InsertTempRedemptionRequest(List<RedemptionViewModel> requestModel);
    Task<bool> MutualFundBuySellApproval(int ID_Portfolio, string cType, string LoginID, int ID_PortfolioContributorAccount, string GetBankAccount, DateTime GetSingleDate);
    Task<int> OpenCustomerAccount(int ucid, int portfolioId, string currencyId, bool isMutualFund = true);
    IQueryable<Portfolio> PortfolioById(int portfolioID);
    Task<int> SaveFixedDepositInvestment(FixedDepositInputParams model, string postedBy, int ucid, bool effectiveDateFromTomorrow = false);
    float GetOfferPriceAsAt(int portfolioId, DateTime endDate, decimal price);
    IQueryable<TransactionViewModel> FetchClientCashTransactions(int ucid);
    IQueryable<RedemptionHistoryViewModel> ListRedemptionHistories();
    Task<List<int>> ListClientPortfolioContributorIds(int uciId);
    Task<List<PublicPortfolioViewModel>> FetchPublicPortfolios(string fundtype = null);
    IQueryable<CustomerActiveDealsModel> GetCustomersActiveFixedDepositDeals(int portfolioContributorId);
    IQueryable<BorrowTerminateDetailModel> GetCustomerBorrowTerminateDetail(int terminateId);
    Task<BorrowTerminateInitialModel> InitializeBorrowTerminate(int dealId, DateTime transDate);
    Task ApproveTermination(int terminateId, string postedBy = "Self");
    Task<List<ClientInvestmentViewModel>> FetchClientInvestmentsWithBorrowingID(int UCID);
    Task<List<ClientInvestmentDTO>> FetchClientAllInvestments(int UCID, string IDBranch);
    Task<bool> AddExistingClientWalletOrder(WalletTransactionModel model);
    Task<bool> UpdateExistingClientWalletOrder(string trasactionRef);
    WalletTransaction GetExistingClientWalletOrder(string trasactionRef);
}
