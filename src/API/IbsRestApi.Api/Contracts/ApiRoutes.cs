namespace IbsRestApi.Api.Contracts;

public static class ApiRoutes
{

    public static class TransactionsRoutes
    {
        public const string InitTransaction = "transactions/initialize";
        public const string InitWalletTransaction = "transactions/wallet/initialize";
        public const string VerifyTransaction = "transactions/verify";
        public const string VerifyWalletTransaction = "transactions/wallet/verify/{tranxRef}";
        public const string GetPaymentPublicKey = "transactions/payment/key";
        
    }        

    public static class AuthRoutes
    {
        public const string Login = "login";
        public const string Register = "register";
        public const string PasswordResetCode = "password-reset/{email}";
        public const string PasswordReset = "password-reset";
        public const string ChangePassword = "change-password";
    }

    public static class SetupRoutes
    {
        public const string Products = "products";
        public const string ProductsByTypes = "products/{product_type}";
        public const string ProductsMinimal = "products/min/{product_type?}";
        public const string AppBranches = "companies";
        public const string FixedDepositRates = "fixed-deposit/rates";
        public const string PublicProducts = "products/public";
        public const string Titles = "titles";
        public const string Occupations = "occupations";
        public const string SourceOfFund = "source-of-fund";
    }

    public static class DashboardRoutes
    {
        public const string MututalFunds = "mutual-fund/{clientId}";
        public const string FixedDeposit = "fixed-deposit/{clientId}";
        public const string FixedDepositProduct = "fixed-deposit/{clientId}/{productId}";
        public const string PortfolioBalance = "portfolio-balance/{clientId}/{branchId}";
        public const string PortfolioBalance2 = "portfolio-balance-single/{clientId}";
        public const string WalletTransactions = "transactions/{clientId}";
        public const string AllClientInvestment = "client/portfolios/{clientId}/{branchId}";
    }

    public static class OnboardingRoutes
    {
        public const string ClientFullDetails = "full-details/{accountCode}";
        public const string GetRelationships = "relationships";
        public const string GetBanks = "banks";
        public const string AddOrUpdateNextOfKin = "next-of-kin";
        public const string AddOrUpdateBankDetail = "banks";
        public const string DeleteBankDetail = "banks/{ucid}/{bankAccountId}";
        public const string FetchBankDetail = "banks/{ucid}";
        public const string AddOrUpdateMinor = "minor";
        public const string AddOrUpdateProfilePicture = "profile-picture";
        public const string SendEmailToken = "email/token";
        public const string ConfirmEmailToken = "email/confirmation";
        public const string UploadAvatar = "avatar";
    }

    public static class WalletRoutes
    {
        public const string FundWallet = "fund";
        public const string WalletBalance = "{currency}/{clientId}";
    }

    public static class FixedDepositRoutes
    {
        public const string Subscribe = "subscribe";
        public const string InitiateTermination = "withdraw/initiate";
        public const string Terminate = "withdraw";
        public const string CustomerActiveDeals = "deals/{ucid:int}/{portfolioId:int}";
        public const string InitializeDealTerminate = "deals/terminate/initiate";
        public const string ConfirmDealTerminate = "deals/terminate/confirm";
    }
    
    public static class MutualFundRoutes
    {
        public const string Subscribe = "subscribe";
        public const string Balance = "balance";
        public const string RedemptionDetails = "redemption/details";
        public const string ListOfRedemptions = "redemptions/{ucid}";
        public const string RedemptionConfirmation = "redemption/confirm";
    }
    
    public static class KycRoutes
    {
        public const string FetchCustomerKyc = "{ucid}";
        public const string AddOrUpdateCustomerKyc = "";
    }
}
