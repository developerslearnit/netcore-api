using IbsRestApi.Application.IMoneytor;
using IbsRestApi.Common;
using IbsRestApi.Domain.Interfaces;
using IbsRestApi.Entities.iMoneytor;
using IbsRestApi.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IbsRestApi.Domain.Services;

public class CashManagementService : ICashManagementService
{
    private readonly iMoneytorContext _context;

    public CashManagementService(iMoneytorContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<PortfolioContributorBasicInformationVewModel>> AllContributorsBasic()
    {
        var contributors = await _context.PortfolioContributors.AsNoTracking().ToListAsync();

        return contributors.Select(c => new PortfolioContributorBasicInformationVewModel()
        {
            contributorId = c.IdPortfolioContributor,
            accountCode = c.AccountCode,
            address01 = c.Address01,
            address02 = c.Address02,
            contactPerson = c.ContactPerson,
            currency = c.IdCurrency,
            email = c.Email,
            fullName = c.FullName,
            mobileNo = c.MobileNo,
            telephone = c.Telephone
        }).AsQueryable();
    }

    public async Task<string> ApproveCashInflowAndOutFlow(string transactionType, int id_portfolioContributorAccount, string id_bankAccount = " ", string chequeNo = "", string paymentType = "", string capturedBy = "")
    {
        var _preference = await FetchPreference();

        bool linkToMoneybook = false;

        if (_preference.Link2MoneyBook.HasValue)
        {
            linkToMoneybook = _preference.Link2MoneyBook.Value;
        }

        if (linkToMoneybook)
        {
            if (transactionType == "S")
            {
                BorrowingAddCash2Moneybook(id_portfolioContributorAccount, capturedBy);
            }
            if (transactionType == "R")
            {
                BorrowingWithdrawCash2Moneybook(id_portfolioContributorAccount, capturedBy);
            }
        }
        else
        {
            if (transactionType == "S")
            {
                BorrowingAddCash2Moneybook2GL(id_portfolioContributorAccount, id_bankAccount, capturedBy);
            }
            if (transactionType == "R")
            {
                BorrowingWithdrawCash2Moneybook2GL(id_portfolioContributorAccount, id_bankAccount, chequeNo, paymentType, capturedBy);
            }
        }

        return string.Empty;

    }

    private void BorrowingAddCash2Moneybook(int id_portfolioContributorAccount, string capturedBy)
    {
        var spName = "iBorrowing_sp_CashManagement2Moneybook";
        var dbName = _context.Database.GetDbConnection().Database;
        // var postedBy = _WebHelpers.GetCurrentLoggingUser();

        _context.Database.ExecuteSqlRaw($"{spName} @ID_PortfolioContributorAccount, @DbName,@PostedBy",
           new SqlParameter("@ID_PortfolioContributorAccount", id_portfolioContributorAccount),
           new SqlParameter("@DbName", dbName),
           new SqlParameter("@PostedBy", capturedBy));
    }

    private void BorrowingWithdrawCash2Moneybook(int id_portfolioContributorAccount, string capturedBy)
    {
        var spName = "iBorrowing_sp_CashManagementWithdraw";
        var dbName = _context.Database.GetDbConnection().Database;
        //var postedBy = "Anchoria";

        _context.Database.ExecuteSqlRaw($"{spName} @ID_PortfolioContributorAccount, @DbName,@LoginID",
           new SqlParameter("@ID_PortfolioContributorAccount", id_portfolioContributorAccount),
           new SqlParameter("@DbName", dbName),
           new SqlParameter("@LoginID", capturedBy));
    }

    private void BorrowingAddCash2Moneybook2GL(int id_portfolioContributorAccount, string idbankAccount, string capturedBy)
    {
        var spName = "iBorrowing_sp_CashManagement2Moneybook2GL";



        _context.Database.ExecuteSqlRaw($"{spName} @ID_PortfolioContributorAccount, @ID_BankAccount,@LoginID",
           new SqlParameter("@ID_PortfolioContributorAccount", id_portfolioContributorAccount),
           new SqlParameter("@ID_BankAccount", idbankAccount),
           new SqlParameter("@LoginID", capturedBy));
    }

    private void BorrowingWithdrawCash2Moneybook2GL(int id_portfolioContributorAccount, string idbankAccount,
        string chequeNo, string paymentType, string capturedBy)
    {
        var spName = "iBorrowing_sp_CashManagementWithdraw2GL";
        //var postedBy = "Anchoria";


        _context.Database.ExecuteSqlRaw($"{spName} @ID_PortfolioContributorAccount, @ID_BankAccount,@LoginID,@ChequeNo,@PaymentType",
           new SqlParameter("@ID_PortfolioContributorAccount", id_portfolioContributorAccount),
           new SqlParameter("@ID_BankAccount", idbankAccount),
           new SqlParameter("@LoginID", capturedBy),
           new SqlParameter("@ChequeNo", chequeNo),
           new SqlParameter("@PaymentType", paymentType));
    }


    public async Task<PortfolioContributorBasicInformationVewModel> FetchContributorsBasicByCurrencyAndUCID(string currency, int ucid)
    {
        var contributorDetails = _context.PortfolioContributors.AsNoTracking().
            Where(x => x.Ucid == ucid && x.IdCurrency == currency).Select(x => new PortfolioContributorBasicInformationVewModel()
            {
                contributorId = x.IdPortfolioContributor,
                accountCode = x.AccountCode,
                address01 = x.Address01,
                address02 = x.Address02,
                contactPerson = x.ContactPerson,
                currency = x.IdCurrency,
                email = x.Email,
                fullName = x.FullName,
                mobileNo = x.MobileNo,
                telephone = x.Telephone
            }).FirstOrDefault();

        if (contributorDetails == null) return new PortfolioContributorBasicInformationVewModel();

        return contributorDetails;
        //return new PortfolioContributorBasicInformationVewModel()
        //{
        //    contributorId = contributorDetails.IdPortfolioContributor,
        //    accountCode = contributorDetails.AccountCode,
        //    address01 = contributorDetails.Address01,
        //    address02 = contributorDetails.Address02,
        //    contactPerson = contributorDetails.ContactPerson,
        //    currency = contributorDetails.IdCurrency,
        //    email = contributorDetails.Email,
        //    fullName = contributorDetails.FullName,
        //    mobileNo = contributorDetails.MobileNo,
        //    telephone = contributorDetails.Telephone
        //};
    }

    public async Task<PortfolioContributorBasicInformationVewModel> FetchContributorsBasicByIdPortfolioAndUCID(int portfolioId, int ucid, string currency)
    {
        var contributorDetails = _context.PortfolioContributors.AsNoTracking().
            Where(x => x.Ucid == ucid && x.IdCurrency == currency && x.IdPortfolio == portfolioId).Select(x => new PortfolioContributorBasicInformationVewModel()
            {
                contributorId = x.IdPortfolioContributor,
                accountCode = x.AccountCode,
                address01 = x.Address01,
                address02 = x.Address02,
                contactPerson = x.ContactPerson,
                currency = x.IdCurrency,
                email = x.Email,
                fullName = x.FullName,
                mobileNo = x.MobileNo,
                telephone = x.Telephone
            }).FirstOrDefault();

        if (contributorDetails == null) return new PortfolioContributorBasicInformationVewModel();

        return contributorDetails;
        //return new PortfolioContributorBasicInformationVewModel()
        //{
        //    contributorId = contributorDetails.IdPortfolioContributor,
        //    accountCode = contributorDetails.AccountCode,
        //    address01 = contributorDetails.Address01,
        //    address02 = contributorDetails.Address02,
        //    contactPerson = contributorDetails.ContactPerson,
        //    currency = contributorDetails.IdCurrency,
        //    email = contributorDetails.Email,
        //    fullName = contributorDetails.FullName,
        //    mobileNo = contributorDetails.MobileNo,
        //    telephone = contributorDetails.Telephone
        //};
    }

    public async Task<Preference> FetchPreference()
    {
        return await _context.Preferences.AsNoTracking().FirstOrDefaultAsync();
    }

    public float GetOfferPriceAsAt(int portfolioId, DateTime endDate, decimal price)
    {
        var outParam = new SqlParameter
        {
            ParameterName = "@BidPrice",
            SqlDbType = SqlDbType.Float,
            Direction = ParameterDirection.Output
        };
        var unitValue = _context.Database.ExecuteSqlRaw("Moneytor_sp_GetOfferPriceAsAt @ID_Portfolio, @EndDate, @BidPrice OUT",
         new SqlParameter("@ID_Portfolio", portfolioId), new SqlParameter("@EndDate", endDate), outParam);
        var result = !string.IsNullOrWhiteSpace(outParam.Value.ToString()) ? outParam.Value.ToString() : "0";
        return float.Parse(result);
    }

    public async Task<bool> MoveMoneyToCashAccount(string productnamee, decimal amount, string id_bankAccount, string customerName,
        string id_currency, int id_portfolioContributor, string id_cashMgtAccount,
        int portfolioId, string caturedBy, decimal unitValue)
    {

        decimal noOfUnits = 0;

        if (portfolioId > 0)
            noOfUnits = (amount / unitValue);

        var newLodgement = new PortfolioContributorAccount()
        {
            IdPortfolioContributor = id_portfolioContributor,
            TransactionDate = DateTime.Now.AddDays(1).Date,
            ValueDate = DateTime.Now.AddDays(1).Date,
            Amount = amount,
            UnitValue = unitValue,
            NoOfUnits = noOfUnits,
            TransactionType = "S",
            ChequeNo = "",
            IdBankAccount = id_bankAccount,
            Status = "P",
            IdPortfolio = portfolioId,// - 1,
            PaymentType = "D",
            IdCurrency = id_currency,
            Comments = $"Cash deposited via online portal On:{DateTime.Now} by {caturedBy}",
            Narration = $"Cash deposited via online portal",
            CapturedBy = "API Trans",
            ReceiptDate = DateTime.Now,
            GrossAmountReceived = amount,
            IdCashMgtAccount = id_cashMgtAccount,
            TransRefNo = DateTime.Now.Ticks.ToString().Right(10),
            CertificateNo = "",
            PenaltyCharge = 0,
            UnitsSold = 0,
            VoucherNo = "",
            GlPostPeriod = "",
            Days2Clear = 0,
            UniqueId = 0,
            DeductStampDuty = false,
            PortfolioDirectInvestment = false,
            CertficateStatus = "P"
        };

        _context.PortfolioContributorAccounts.Add(newLodgement);

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }

    public async Task<bool> InserIntoPortfoliContributorAccount(string productnamee, decimal amount, string id_bankAccount,
        string customerName, string id_currency, int id_portfolioContributor, string id_cashMgtAccount,
        int portfolioId, string capturedBy, decimal unitValue, string application = "API")
    {

        decimal noOfUnits = 0;
        var _unitValue = unitValue == 0 ? 5 : unitValue;
        if (portfolioId > 0)
            noOfUnits = (amount / _unitValue);
        var customerPortfolioContributor = _context.PortfolioContributorAccounts.FirstOrDefault(p => p.IdPortfolioContributor == id_portfolioContributor);
        var newLodgement = new PortfolioContributorAccount()
        {
            IdPortfolioContributor = id_portfolioContributor,
            TransactionDate = DateTime.Now.AddDays(1).Date,
            ValueDate = DateTime.Now.AddDays(1).Date,
            Amount = amount,
            UnitValue = unitValue,
            NoOfUnits = noOfUnits,
            TransactionType = "S",
            ChequeNo = "",
            IdBankAccount = id_bankAccount,
            Status = "P",
            IdPortfolio = portfolioId,// - 1,
            PaymentType = "D",
            IdCurrency = id_currency,
            Comments = $"Subscription via online portal On:{DateTime.Now} by {capturedBy}",
            Narration = $"Subscription via online portal",
            CapturedBy = capturedBy,
            ReceiptDate = DateTime.Now,
            GrossAmountReceived = amount,
            IdCashMgtAccount = id_cashMgtAccount,
            TransRefNo = DateTime.Now.Ticks.ToString().Right(10),
            CertificateNo = "",
            PenaltyCharge = 0,
            UnitsSold = 0,
            VoucherNo = "",
            GlPostPeriod = "",
            Days2Clear = 0,
            UniqueId = 0,
            DeductStampDuty = false,
            PortfolioDirectInvestment = false,
            CertficateStatus = "P",
            IdPortfolioContributorBulkAccount = 0,
            IdPortfolioDirect = customerPortfolioContributor != null ? customerPortfolioContributor.IdPortfolioDirect : 0,
            IdApplication = application
        };

        _context.PortfolioContributorAccounts.Add(newLodgement);

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }


    public IQueryable<WalletModel> FetchClientWalletTransactions(int ucid)
    {
        IQueryable<WalletModel> walletTrans = null;
        int[] contributorIds;
        var contributor = _context.PortfolioContributors.AsNoTracking().Where(x => x.Ucid == ucid && x.IdPortfolio == -1);

        if (contributor.Any())
        {
            contributorIds = contributor.Select(c => c.IdPortfolioContributor).ToArray();

            walletTrans = _context.PortfolioContributorAccounts
                .Where(p => contributorIds.Contains(p.IdPortfolioContributor.Value))
                .Select(pc => new WalletModel
                {
                    amount = pc.Amount.HasValue ? pc.Amount.Value : 0,
                    currency = pc.IdCurrency,
                    narration = pc.Narration,
                    transactionDate = pc.TransactionDate.Value
                });
        }

        return walletTrans;

    }


    public IQueryable<ClientWalletModel> GetClientWalletTransactions(int ucid)
    {
        IQueryable<ClientWalletModel> walletTrans = null;
        int[] contributorIds;
        var contributor = _context.PortfolioContributors.AsNoTracking().Where(x => x.Ucid == ucid && x.IdPortfolio == -1);

        if (contributor.Any())
        {
            contributorIds = contributor.Select(c => c.IdPortfolioContributor).ToArray();

            walletTrans = _context.PortfolioContributorAccounts
                .Where(p => contributorIds.Contains(p.IdPortfolioContributor.Value) && p.IdPortfolio == -1)
                .Select(pc => new ClientWalletModel
                {
                    amount = pc.Amount.HasValue ? pc.Amount.Value : 0,
                    currency = pc.IdCurrency
                });
        }
        return walletTrans;

    }



    public async Task<bool> WithdrawFromCashAccount(decimal amount, string id_bankAccount, string customerName, string id_currency, int id_portfolioContributor, string id_cashMgtAccount, string withdrawBy)
    {
        var newLodgement = new PortfolioContributorAccount()
        {
            IdPortfolioContributor = id_portfolioContributor,
            TransactionDate = DateTime.Now,
            ValueDate = DateTime.Now,
            Amount = -amount,
            UnitValue = 0,
            NoOfUnits = 0,
            TransactionType = "S",
            ChequeNo = "",
            IdBankAccount = id_bankAccount,
            Status = "P",
            IdPortfolio = -1,
            PaymentType = "D",
            IdCurrency = id_currency,
            Comments = $"Cash Widthdrawal by {customerName} on {DateTime.Now}",
            Narration = $"Cash Widthdrawal by {customerName} on {DateTime.Now}",
            CapturedBy = withdrawBy,
            ReceiptDate = DateTime.Now,
            GrossAmountReceived = -amount,
            IdCashMgtAccount = id_cashMgtAccount,
            TransRefNo = DateTime.Now.Ticks.ToString().Right(10),
            CertificateNo = "",
            PenaltyCharge = 0,
            UnitsSold = 0,
            VoucherNo = "",
            GlPostPeriod = "",
            Days2Clear = 0,
            UniqueId = 0,
            DeductStampDuty = false,
            PortfolioDirectInvestment = false
        };

        _context.PortfolioContributorAccounts.Add(newLodgement);

        var result = await _context.SaveChangesAsync();

        return result > 0;
    }


    public async Task<decimal> GetClientCashBalance(string currencyId, int ucid, int portfolioId)
    {
        var getClientSPName = "OnBoarding_sp_GetPortfolioContributor";

        int IdportfolioContributor = 0;

        var portfolioContributorId = new SqlParameter()
        {
            ParameterName = "@ID_PortfolioContributor",
            Direction = ParameterDirection.Output,
            SqlDbType = SqlDbType.Int
        };


        await _context.Database.ExecuteSqlRawAsync($"{getClientSPName} @UCID,@ID_Portfolio,@ID_Currency,@ID_PortfolioContributor OUT",
         new SqlParameter("@UCID", ucid),
            new SqlParameter("@ID_Portfolio", portfolioId),
            new SqlParameter("@ID_Currency", currencyId),
            portfolioContributorId);

        IdportfolioContributor = int.Parse(!string.IsNullOrWhiteSpace(portfolioContributorId.Value.ToString()) ? portfolioContributorId.Value.ToString() : "0");

        if (IdportfolioContributor == 0) return 0M;

        return GetClientCashBalance(IdportfolioContributor, 0, DateTime.Now, 0);

    }

    public decimal GetClientCashBalance(int id_portfolioContributor, int idPortfolio_Owner, DateTime endDate, int ID_PortfolioContributorAccount = 0)
    {
        var idPAccount = ID_PortfolioContributorAccount;

        var spName = "Borrowing_sp_CashBalance";
        var balanceParam = new SqlParameter()
        {
            ParameterName = "@Balance",
            Direction = System.Data.ParameterDirection.Output,
            SqlDbType = System.Data.SqlDbType.Decimal
        };


        _context.Database.ExecuteSqlRaw($"{spName} @ID_PortfolioContributor, @ID_Portfolio_Owner,@EndDate," +
            $"@Balance OUT,@ID_PortfolioContributorAccount",
           new SqlParameter("@ID_PortfolioContributor", id_portfolioContributor),
           new SqlParameter("@ID_Portfolio_Owner", idPortfolio_Owner),
           new SqlParameter("@EndDate", endDate),
           balanceParam,
           new SqlParameter("@ID_PortfolioContributorAccount", idPAccount));

        var outputValue = balanceParam.Value;
        if (decimal.TryParse(outputValue.ToString(), out decimal _out))
        {
            return Convert.ToDecimal(balanceParam.Value);
        }

        return 0;

    }


    public async Task<bool> GetPreviousTransactionReference(string transRef)
    {
        var exist = await _context.PortfolioContributorAccounts.AsNoTracking().FirstOrDefaultAsync(x => x.TransRefNo == transRef);
        return exist != null;
    }

    public void WalletDepositOrWithdraw(int UCID, string ID_Currency, decimal Amount,
        string ID_BankAccount, string ID_CashMgtAccount, string TransUniqueRefNo,
        string DepositOrWithdraw = "D")
    {

        var spName = "Borrow_sp_Wallet_Deposit_or_Withdraw";
        var dbName = _context.Database.GetDbConnection().Database;
        // var postedBy = _WebHelpers.GetCurrentLoggingUser();

        int resul = _context.Database.ExecuteSqlRaw($"{spName} " +
                $"@UCID,@ID_Currency,@Amount,@ID_BankAccount,@ID_CashMgtAccount,@TransUniqueRefNo," +
                $"@DepositOrWithdraw",
               new SqlParameter("@UCID", UCID),
               new SqlParameter("@ID_Currency", ID_Currency),
               new SqlParameter("@Amount", Amount),
               new SqlParameter("@ID_BankAccount", ID_BankAccount),
               new SqlParameter("@ID_CashMgtAccount", ID_CashMgtAccount),
               new SqlParameter("@TransUniqueRefNo", TransUniqueRefNo),
               new SqlParameter("@DepositOrWithdraw", DepositOrWithdraw)


               );
    }
}
