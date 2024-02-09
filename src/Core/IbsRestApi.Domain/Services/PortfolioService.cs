using IbsRestApi.Application.IMoneytor;
using IbsRestApi.Application.Portfolios;
using IbsRestApi.Common;
using IbsRestApi.Domain.Interfaces;
using IbsRestApi.Entities.iMoneytor;
using IbsRestApi.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IbsRestApi.Domain.Services;

public class PortfolioService : IPortfolioService
{
    private readonly iMoneytorContext _context;
    private readonly MdmContext _mdmContext;

    public PortfolioService(iMoneytorContext context, MdmContext mdmContext)
    {
        _context = context;
        _mdmContext = mdmContext;
    }

    public async Task<int> OpenCustomerAccount(int ucid, int portfolioId, string currencyId, bool isMutualFund = true)
    {
        var checkSPName = "OnBoarding_sp_GetPortfolioContributor";
        var openSPName = "OnBoarding_sp_OpenCustomerAccount ";
        int IdportfolioContributor = 0;

        var portfolioContributorId = new SqlParameter()
        {
            ParameterName = "@ID_PortfolioContributor",
            Direction = ParameterDirection.Output,
            SqlDbType = SqlDbType.Int
        };

        portfolioId = !isMutualFund ? -1 : portfolioId;

        await _context.Database.ExecuteSqlRawAsync($"{checkSPName} @UCID,@ID_Portfolio,@ID_Currency,@ID_PortfolioContributor OUT",
         new SqlParameter("@UCID", ucid),
            new SqlParameter("@ID_Portfolio", portfolioId),
            new SqlParameter("@ID_Currency", currencyId),
            portfolioContributorId);

        IdportfolioContributor = int.Parse(!string.IsNullOrWhiteSpace(portfolioContributorId.Value.ToString()) ? portfolioContributorId.Value.ToString() : "0");

        if (IdportfolioContributor <= 0)
        {

            var ContributorId = new SqlParameter()
            {
                ParameterName = "@ID_PortfolioContributor",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int
            };

            await _context.Database.ExecuteSqlRawAsync($"{openSPName} @UCID,@ID_Portfolio,@ID_Currency,@ID_PortfolioContributor OUT",
                new SqlParameter("@UCID", ucid),
            new SqlParameter("@ID_Portfolio", portfolioId),
            new SqlParameter("@ID_Currency", currencyId),
            ContributorId);

            IdportfolioContributor = int.Parse(!string.IsNullOrWhiteSpace(ContributorId.Value.ToString()) ? ContributorId.Value.ToString() : "0");
        }

        return IdportfolioContributor;

    }

    public IQueryable<ClientOwnedPortfolios> FetchClientOwnedPortfolios()
    {
        return from pca in _context.PortfolioContributorAccounts.AsNoTracking()
               join pc in _context.PortfolioContributors.AsNoTracking()
               on pca.IdPortfolioContributor equals pc.IdPortfolioContributor
               join p in _context.Portfolios on pc.IdPortfolio equals p.IdPortfolio
               select new ClientOwnedPortfolios
               {
                   IdPortfolioContributor = pca.IdPortfolioContributor.Value,
                   ucid = pc.Ucid.Value,
                   IdPortfolio = p.IdPortfolio,
                   portfolioName = p.Portfolio1,
                   unitBased = p.UnitBased.HasValue ? p.UnitBased.Value : false,
                   stableNav = p.StableVav.HasValue ? p.StableVav.Value : false,
                   TransactionDate = pca.ValueDate.Value,
                   InvestmentAmount = pca.Amount.Value,
               };
    }

    public async Task<PortfolioContributor> GetPortfolioContributor(int ucid, string currency)
    {
        return await _context.PortfolioContributors.AsNoTracking().Where(x => x.Ucid.Value == ucid && x.IdCurrency == currency).FirstOrDefaultAsync();
    }

    public IEnumerable<BorrowingProductViewModel> AllBorrowing()
    {
        return from _borrowing in _context.BorrowMasters
               join _btype in _context.BorrowTypes
                   on _borrowing.IdBorrowType equals _btype.IdBorrowType
               where _borrowing.Status == "A"
               select new BorrowingProductViewModel()
               {
                   currency = _borrowing.IdCurrency,
                   description = _borrowing.Description,
                   borrowAmount = _borrowing.BorrowAmount.HasValue ? _borrowing.BorrowAmount.Value : 0,
                   clientId = _borrowing.IdPortfolioContributor.Value,
                   dealId = _borrowing.IdBorrowMaster,
                   effectiveDate = _borrowing.EffectiveDate.Value,
                   faceAmount = _borrowing.FaceAmount.Value,
                   interestRate = _borrowing.InterestRate.Value,
                   maturityDate = _borrowing.MaturityDate.Value,
                   numofDays = _borrowing.NoOfDays.Value,
                   productName = _btype.BorrowType1,
                   rentalAmount = _borrowing.RentalAmount.Value,
                   transactionDate = _borrowing.TransactionDate.Value,
                   curExchangeRate = _borrowing.CurExRate.Value,
                   firstPaymentDate = _borrowing.FirstPaymentDueDate.Value,
                   productId = _borrowing.IdBorrowMaster,
               };
    }

    public async Task<List<ClientInvestmentViewModel>> FetchClientInvestments(int UCID)
    {
        string spName = "ClientPortal_sp_InvestmentByModule";

        var _spContext = _mdmContext.LoadStoredProc(spName)
                                    .WithSqlParam((nameof(UCID), UCID));

        _spContext.CommandTimeout = 6000;
        var result = await _spContext.ExecuteStoreProcedure<ClientInvestmentViewModel>();
        return result;
    }

    //

    public async Task<List<ClientInvestmentDTO>> FetchClientAllInvestments(int UCID, string IDBranch)
    {
        string spName = "ClientPortal_sp_InvestmentByModule_API_byAppbranch";
         var _dbcontext = _mdmContext.LoadStoredProc(spName)
                              .WithSqlParam((nameof(UCID), UCID), (nameof(IDBranch), IDBranch));
        _dbcontext.CommandTimeout = 6000;
        return await _dbcontext.ExecuteStoreProcedure<ClientInvestmentDTO>();

    }

    public async Task<List<ClientInvestmentViewModel>> FetchClientInvestmentsWithBorrowingID(int UCID)
    {
        string spName = "ClientPortal_sp_InvestmentByModule_API";
               

        var _spContext = _mdmContext.LoadStoredProc(spName)
                                    .WithSqlParam((nameof(UCID), UCID));

        _spContext.CommandTimeout = 6000;
        return await _spContext.ExecuteStoreProcedure<ClientInvestmentViewModel>();

    }

    public int GetUCIDWithAccountCode(string accountCode)
    {
        int ucid = 0;
        var account = _context.PortfolioContributors.AsNoTracking().FirstOrDefault(x => x.AccountCode.Equals(accountCode));
        if (account != null) { ucid = account.Ucid ?? 0; };
        return ucid;
    }

    public async Task<float> FetchCustomerCashBalance(int ucid, int portfolioId, string currency, int portfolioOwnerId, DateTime endDate)
    {
        var checkSPName = "OnBoarding_sp_GetPortfolioContributor";
        var balanceSPName = "Borrowing_sp_CashBalance ";
        int IdportfolioContributor = 0;

        var portfolioContributorId = new SqlParameter()
        {
            ParameterName = "@ID_PortfolioContributor",
            Direction = ParameterDirection.Output,
            SqlDbType = SqlDbType.Int
        };


        await _context.Database.ExecuteSqlRawAsync($"{checkSPName} @UCID,@ID_Portfolio,@ID_Currency,@ID_PortfolioContributor OUT",
         new SqlParameter("@UCID", ucid),
            new SqlParameter("@ID_Portfolio", portfolioId),
            new SqlParameter("@ID_Currency", currency),
            portfolioContributorId);

        IdportfolioContributor = int.Parse(!string.IsNullOrWhiteSpace(portfolioContributorId.Value.ToString()) ?
           portfolioContributorId.Value.ToString() : "0");

        if (IdportfolioContributor == 0)
        {
            return 0;
        }
        else
        {
            var balance = new SqlParameter()
            {
                ParameterName = "@Balance",
                Direction = ParameterDirection.Output,
                SqlDbType = SqlDbType.Float
            };

            int IdPortfolioContributorAccount = 0;

            await _context.Database.ExecuteSqlRawAsync($"{balanceSPName} @ID_PortfolioContributor,@ID_Portfolio_Owner,@EndDate,@Balance OUT,@ID_PortfolioContributorAccount",
             new SqlParameter("@ID_PortfolioContributor", IdportfolioContributor),
                new SqlParameter("@ID_Portfolio_Owner", portfolioOwnerId),
                new SqlParameter("@EndDate", endDate),
                balance, new SqlParameter("@ID_PortfolioContributorAccount", IdPortfolioContributorAccount));

            return float.Parse(!string.IsNullOrWhiteSpace(balance.Value.ToString()) ? balance.Value.ToString() : "0");
        }

    }

    public FixedDepositOutputParam GetGeneric_sp_CalculateInterest(GenericSPForCalculatingInterest model, int productid)
    {
        var borrowType = _context.BorrowTypes.AsNoTracking().Where(c => c.IdPortfolio == productid).FirstOrDefault();

        var spName = "Generic_sp_CalculateInterest";

        var effectIntRate = new SqlParameter()
        {
            ParameterName = "@EffIntRate",
            Direction = System.Data.ParameterDirection.Output,
            SqlDbType = System.Data.SqlDbType.Float
        };
        var mayurityDate = new SqlParameter()
        {
            ParameterName = "@MaturityDate",
            Direction = System.Data.ParameterDirection.Output,
            SqlDbType = System.Data.SqlDbType.DateTime
        };
        var settleMentDate = new SqlParameter()
        {
            ParameterName = "@SettlememtDate",
            Direction = System.Data.ParameterDirection.Output,
            SqlDbType = System.Data.SqlDbType.DateTime
        };
        var borrowAmount = new SqlParameter()
        {
            ParameterName = "@BorrowAmount",
            Direction = System.Data.ParameterDirection.Output,
            SqlDbType = System.Data.SqlDbType.Float
        };
        var interestAmount = new SqlParameter()
        {
            ParameterName = "@InterestAmount",
            Direction = System.Data.ParameterDirection.Output,
            SqlDbType = System.Data.SqlDbType.Float
        };
        var withTax = new SqlParameter()
        {
            ParameterName = "@WithTax",
            Direction = System.Data.ParameterDirection.Output,
            SqlDbType = System.Data.SqlDbType.Float
        };
        var netMatureValeu = new SqlParameter()
        {
            ParameterName = "@NetMatValue",
            Direction = System.Data.ParameterDirection.Output,
            SqlDbType = System.Data.SqlDbType.Float
        };

        _context.Database.ExecuteSqlRaw($"{spName} @FaceAmount, @IntRate, @IntMode,@IntType,@CapitalisedUpfrontInterest,@EffDate,@Tenor," +
       "@ApplyWTax,@EffIntRate OUT,@MaturityDate OUT,@SettlememtDate OUT,@BorrowAmount OUT,@InterestAmount OUT,@WithTax OUT,@NetMatValue OUT",
        new SqlParameter("@FaceAmount", model.FaceAmount),
        new SqlParameter("@IntRate", model.IntRate),
        new SqlParameter("@IntMode", model.IntMode),
        new SqlParameter("@IntType", model.IntType),
        new SqlParameter("@CapitalisedUpfrontInterest", model.CapitalisedUpfrontInterest),
        new SqlParameter("@EffDate", model.EffDate),
        new SqlParameter("@Tenor", model.Tenor),
        new SqlParameter("@ApplyWTax", model.ApplyWTax),
        effectIntRate, mayurityDate, settleMentDate,
        borrowAmount, interestAmount, withTax, netMatureValeu
        );

        var _effectIntRate = string.Format("{0:n}", (float.Parse(!string.IsNullOrWhiteSpace(effectIntRate.Value.ToString()) ? effectIntRate.Value.ToString() : null)));

        var _mayurityDate = DateTime.Parse(!string.IsNullOrWhiteSpace(mayurityDate.Value.ToString()) ? mayurityDate.Value.ToString() : null);

        var _settleMentDate = DateTime.Parse(!string.IsNullOrWhiteSpace(settleMentDate.Value.ToString()) ? settleMentDate.Value.ToString() : null);

        var _borrowAmount = string.Format("{0:n}", (float.Parse(!string.IsNullOrWhiteSpace(borrowAmount.Value.ToString()) ? borrowAmount.Value.ToString() : null)));

        var _interestAmoun = interestAmount.Value.ToString();


        var _interestAmount = string.Format("{0:n}", (float.Parse(!string.IsNullOrWhiteSpace(interestAmount.Value.ToString()) ? interestAmount.Value.ToString() : null)));

        var _withTax = string.Format("{0:n}", (float.Parse(!string.IsNullOrWhiteSpace(withTax.Value.ToString()) ? withTax.Value.ToString() : null)));

        var _netMatureValeu = string.Format("{0:n}", (float.Parse(!string.IsNullOrWhiteSpace(netMatureValeu.Value.ToString()) ? netMatureValeu.Value.ToString() : null)));

        var maturityValue = Convert.ToDecimal(_borrowAmount) + Convert.ToDecimal(_interestAmount);
        var totalded = Convert.ToDecimal(_withTax) + (Convert.ToDecimal(_interestAmount) * (borrowType.MgtFeesRate.Value / 100));
        var managmenFees = Convert.ToDecimal(_interestAmount) * (borrowType.MgtFeesRate.Value / 100);
        var interestCalOutput = new FixedDepositOutputParam()
        {
            EffIntRate = _effectIntRate + "%",
            BorrowAmount = _borrowAmount,
            InterestAmount = _interestAmount,
            MaturityDate = _mayurityDate,
            NetMatValue = _netMatureValeu,
            SettlememtDate = _settleMentDate,
            WithTax = _withTax,
            ManagementFees = string.Format("{0:n}", (managmenFees)),
            MaturityValue = string.Format("{0:n}", (maturityValue))
        };

        return interestCalOutput;
    }

    public string FetchPortfolioCurrency(int portfolioId)
    {
        return _context.Portfolios.AsNoTracking().Where(x => x.IdPortfolio == portfolioId).Select(p => p.IdCurrency).FirstOrDefault();
    }

    public IQueryable<Portfolio> PortfolioById(int portfolioID)
    {
        return _context.Portfolios.AsNoTracking().Where(m => m.IdPortfolio == portfolioID);

    }

    public async Task<List<PortfolioBankAccount>> FetchPortfolioBankAccounts()
    {
        var cmdText = "SELECT ID_Portfolio portfolioId,BankCode bankCode,AccountNumber accountNumber FROM OnlinePortfolio";

        var _commandContext = _context.LoadSqlQuery(cmdText);

        var _commandResult = await _commandContext.ExecuteStoreProcedure<PortfolioBankAccount>();

        return _commandResult;
    }

    public IQueryable<BorrowTypeModel> FetchBorrowTypeList()
    {
        return _context.BorrowTypes.AsNoTracking().Select(p => new BorrowTypeModel()
        {
            ApplyMgtFees = p.ApplyMgtFees,
            ApplyWithTax = p.ApplyWithTax,
            BorrowAccrualActNo = p.BorrowAccrualActNo,
            BorrowAccrualActNoCcenter = p.BorrowAccrualActNoCcenter,
            BorrowExpenseActNo = p.BorrowExpenseActNo,
            BorrowExpenseActNoCcenter = p.BorrowExpenseActNoCcenter,
            BorrowMainActNo = p.BorrowMainActNo,
            BorrowMainActNoCcenter = p.BorrowMainActNoCcenter,
            BorrowType1 = p.BorrowType1,
            CalculationMethod = p.CalculationMethod,
            CapitaliseUpfrontInterest = p.CapitaliseUpfrontInterest,
            Com1Rate = p.Com1Rate,
            Com2Rate = p.Com2Rate,
            IdBizUnit = p.IdBizUnit,
            IdBorrowType = p.IdBorrowType,
            IdInvestmentType = p.IdInvestmentType,
            IdPortfolio = p.IdPortfolio,
            InterestPaidUpfront = p.InterestPaidUpfront,
            MgtFeeActNo = p.MgtFeeActNo,
            MgtFeeActNoCcenter = p.MgtFeeActNoCcenter,
            MgtFeesOnInterest = p.MgtFeesOnInterest,
            MgtFeesRate = p.MgtFeesRate,
            PartialPenaltyRate = p.PartialPenaltyRate,
            PenaltyActNo = p.PenaltyActNo,
            PenaltyFixedAmount = p.PenaltyFixedAmount,
            PenaltyRate = p.PenaltyRate,
            TerminationPenaltyType = p.TerminationPenaltyType,
            TreatAsCall = p.TreatAsCall,
            TreatAsCommercialPaper = p.TreatAsCommercialPaper,
            TreatAsTreasuryBill = p.TreatAsTreasuryBill,
            Upid = p.Upid
        });
    }

    public IQueryable<BorrowRateModel> FetchPublicFixedDepositRateGap()
    {
        return _context.BorrowRateTables.AsNoTracking().Select(p => new BorrowRateModel()
        {
            CaptureDate = p.CaptureDate,
            CapturedBy = p.CapturedBy,
            Comments = p.Comments,
            EffectiveDate = p.EffectiveDate,
            FromAmount = p.FromAmount,
            FromTenor = p.FromTenor,
            IdBorrowRateTable = p.IdBorrowRateTable,
            IdBorrowType = p.IdBorrowType,
            IntRate = p.IntRate,
            ModifiedBy = p.ModifiedBy,
            ModifiedDate = p.ModifiedDate,
            ToAmount = p.ToAmount,
            ToTenor = p.ToTenor
        });
    }

    public async Task<bool> InsertCustomerBorrowTransaction(int portfolioId, int idPortfolioContributor,
       DateTime transactionDate, DateTime valueDate, decimal amount, string transactionType,
       string narration, string currencyId, string comment, string capturedBy, string application = "API")
    {

        decimal unitValue = 0;
        decimal noOfUnits = 0;
        string status = "A";

        var currencyMapping = _mdmContext.CurrencyAccountMappings.AsNoTracking().FirstOrDefault(c => c.IdCurrency == currencyId);
        var contributorAccount = new PortfolioContributorAccount()
        {
            IdPortfolioContributor = idPortfolioContributor,
            TransactionDate = transactionDate,
            ValueDate = valueDate.Date,
            Amount = amount,
            UnitValue = unitValue,
            NoOfUnits = noOfUnits,
            TransactionType = transactionType,
            CertficateStatus = "P",
            CertificateUnits = 0,
            Reversed = 0,
            ReversalId = 0,
            Status = status,
            IdPortfolio = portfolioId,
            CertificateNo = " ",
            PaymentType = "O",
            Comments = comment,// $"Subscription via online portal On:{DateTime.Now},New Client",
            Narration = narration,
            PenaltyCharge = 0,
            UnitsSold = 0,
            IdCurrency = currencyId,
            CapturedBy = capturedBy.Left(20),
            ReceiptDate = valueDate,
            Days2Clear = 0,
            CostOfUnits = amount,
            IdApplication = application
        };

        _context.PortfolioContributorAccounts.Add(contributorAccount);
        if (currencyMapping != null)
        {
            contributorAccount.IdBank = currencyMapping.IdBankAccount;
        }
        await _context.SaveChangesAsync();
        // Post cash to gl

        if (currencyMapping != null)
        {
            await PostCashToGL(contributorAccount.IdPortfolioContributorAccount, currencyMapping.IdBankAccount, capturedBy.Left(20));
        }

        return true;
    }

    public async Task PostCashToGL(int portfolioContributorAccountId, string bankAccountId, string loginId)
    {
        var unitValue = await _context.Database.ExecuteSqlRawAsync("iBorrowing_sp_CashManagement2Moneybook2GL @ID_PortfolioContributorAccount, @ID_BankAccount, @LoginID",
            new SqlParameter("@ID_PortfolioContributorAccount", portfolioContributorAccountId),
            new SqlParameter("@ID_BankAccount", bankAccountId),
            new SqlParameter("@LoginID", loginId)
            );
    }

    public async Task<int> SaveFixedDepositInvestment(FixedDepositInputParams model, string postedBy, int ucid, bool effectiveDateFromTomorrow = false)
    {
        var borrowMasterId = 0;
        {
            var borrowType = _context.BorrowTypes.Where(c => c.IdPortfolio == model.productID).FirstOrDefault();
            var portfCtr = _context.PortfolioContributors.Where(p => p.Ucid == ucid && p.IdCurrency == model.currencyID).Select(x => x.IdPortfolioContributor).FirstOrDefault();
            var prefrence = _context.Preferences.FirstOrDefault();
            postedBy = string.Join(" ", postedBy.Split(' ').Where(g => g.Length > 0).ToList());
            string description = postedBy + " :" + borrowType.IdBorrowType + " " + model.Tenor;
            description = description.Length > 100 ? description.Substring(0, 100) : description;
            var insertBorrowMaster = new BorrowMaster()
            {
                Agent01 = "",
                Agent02 = "",
                Amt2Add = 0,
                Amt2Withdraw = 0,
                ApplyVat = false,
                ApplyWithTax = borrowType.ApplyWithTax,
                ApprovedBy = "",
                ApprovedDate = null,
                AutoRollOverType = "0",
                AvailmentFees = 0,
                AvailmentFeesRate = 0,
                BestFaceValue = 0,
                BorrowAmount = model.FaceAmount,
                BorrowNumber = "",
                BrokerId = "",
                CalcBestFaceValue = false,
                CalculationMethod = "S",
                CapitaliseFees = false,
                CapitaliseMoratorium = false,
                CapitaliseUpfrontInterest = borrowType.CapitaliseUpfrontInterest,
                CapturedBy = "Self",
                CapturedDate = DateTime.Now.Date,
                ChargeMgtFeesOnInterest = borrowType.MgtFeesOnInterest,
                Com1Rate = borrowType.Com1Rate,
                Com2Rate = borrowType.Com2Rate,
                ComisionRate = 0,
                CommisionAmount = 0,
                CompoundIntType = 0,
                CurExRate = 0,
                DeductInterestEvery = "",
                DeductStampDuty = 0,
                Description = description,
                Discountable = false,
                EffectiveDate = effectiveDateFromTomorrow ? DateTime.Now.AddDays(1) : DateTime.Now,
                EffectiveYield = model.effectIntRate,
                ExtBorrowNumber = "",
                FaceAmount = model.FaceAmount,
                FeesPosted = false,
                FirstPaymentDueDate = Convert.ToDateTime(model.smaturityDate).AddDays(1),
                Id2Cr = 0,
                IdBorrowType = borrowType.IdBorrowType,
                IdBranch = borrowType.IdBizUnit,
                IdCro = 0,
                WhtRate = model.WhtTaxAmt,
                IdCurrency = model.currencyID,
                IdLocation = borrowType.IdBizUnit,
                InterestAmount = model.IntAmount,
                InterestMode = model.IntMode,
                InterestPaidUpfront = borrowType.InterestPaidUpfront,
                InterestRate = model.IntRate,
                InvestmentType = "",
                ManagementFees = borrowType.MgtFeesRate,
                ManagementFeesRate = borrowType.MgtFeesRate,
                MaturityDate = model.smaturityDate,
                NoOfDays = model.Tenor,
                NewMatureValue = model.maturityValue,
                NoOfMonths = 0,
                OriginalIdBorrowMaster = 0,
                Notes = "New Deal Booking by " + postedBy + " " + DateTime.Now.Date,
                RentalAmount = 0,
                Ucid = ucid,
                TransactionDate = DateTime.Now.Date,
                TotalFess = model.managementFee,
                Status = "P",
                SettlementDate = model.smaturityDate.Value.AddDays(1),
                IdPortfolioContributor = model.portfolioContributorId,
                WithholdTaxAmount = model.WhtTaxAmt,
                VatAmount = 0,
                IdProductLine = prefrence.IdProductLine
            };

            await _context.BorrowMasters.AddAsync(insertBorrowMaster);
            await _context.SaveChangesAsync();

            borrowMasterId = insertBorrowMaster.IdBorrowMaster;

            var compoundEveryXmth = 0;
            //call sp
            var spName = "Borrow_sp_BuildIntSchedule_new";
            _context.Database.SetCommandTimeout(60000);
            var res = _context.Database.ExecuteSqlRaw($"{spName} @ID_BorrowMaster,@UpdateLife,@EffDate,@FaceAmount,@Status,@IntRate,@IntMode,@IntPaidUpFront,@UpFrontCapitalised,@BorrowAmount,@MatureDate,@EffectiveRate,@TabName,@ThisIsTermiation,@CompoundEveryXmths",
             new SqlParameter("@ID_BorrowMaster", borrowMasterId),
             new SqlParameter("@UpdateLife", true),
             new SqlParameter("@EffDate", DateTime.Now.Date),
             new SqlParameter("@FaceAmount", model.FaceAmount),
             new SqlParameter("@Status", "P"),
             new SqlParameter("@IntRate", model.IntRate),
             new SqlParameter("@IntMode", "L"),
             new SqlParameter("@IntPaidUpFront", borrowType.InterestPaidUpfront),
             new SqlParameter("@UpFrontCapitalised", borrowType.CapitaliseUpfrontInterest),
             new SqlParameter("@BorrowAmount", model.BorrowAmt),
             new SqlParameter("@MatureDate", model.smaturityDate),
             new SqlParameter("@EffectiveRate", model.effectIntRate),
             new SqlParameter("@TabName", ""),
             new SqlParameter("@ThisIsTermiation", false),
             new SqlParameter("@CompoundEveryXmths", compoundEveryXmth)); ////You cant pass the value of any parameter that is the value is zero like this

            var _success = new SqlParameter()
            {
                ParameterName = "@Success",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int
            };

            var postBorrowing = "Borrowing_sp_PostBorrowing";
            var result = _context.Database.ExecuteSqlRaw($"{postBorrowing} @ID_BorrowMaster,@Postedby,@Success OUT",
            new SqlParameter("@ID_BorrowMaster", borrowMasterId),
            new SqlParameter("@Postedby", postedBy),
            _success
            );
            return borrowMasterId;
        }
    }

    public bool AddCustomerDebitTransaction(int idPortfolioContributor,
       DateTime transactionDate, DateTime valueDate, decimal amount, string transactionType,
       string narration, string currencyId, string comment, string capturedBy)
    {

        int idPortfolio = -1;
        string status = "A";

        var checkSPName = "OnBoarding_sp_GetPortfolioContributor";

        int IdportfolioContributor = 0;

        var portfolioContributorId = new SqlParameter()
        {
            ParameterName = "@ID_PortfolioContributor",
            Direction = ParameterDirection.Output,
            SqlDbType = SqlDbType.Int
        };

        _context.Database.SetCommandTimeout(60000);
        _context.Database.ExecuteSqlRaw($"{checkSPName} @UCID,@ID_Portfolio,@ID_Currency,@ID_PortfolioContributor OUT",
        new SqlParameter("@UCID", idPortfolioContributor),
           new SqlParameter("@ID_Portfolio", idPortfolio),
           new SqlParameter("@ID_Currency", currencyId),
           portfolioContributorId);

        IdportfolioContributor = int.Parse(!string.IsNullOrWhiteSpace(portfolioContributorId.Value.ToString()) ?
           portfolioContributorId.Value.ToString() : "0");


        var contributorAccount = new PortfolioContributorAccount()
        {
            IdPortfolioContributor = IdportfolioContributor,
            TransactionDate = transactionDate,
            ValueDate = valueDate.Date,
            Amount = -amount,
            UnitValue = 0,
            NoOfUnits = 0,
            TransactionType = transactionType,
            CertficateStatus = "P",
            CertificateUnits = 0,
            Reversed = 0,
            ReversalId = 0,
            Status = status,
            IdPortfolio = idPortfolio,
            CertificateNo = " ",
            PaymentType = "W",
            Comments = comment,// $"Subscription via online portal On:{DateTime.Now},New Client",
            Narration = narration,
            PenaltyCharge = 0,
            UnitsSold = 0,
            IdCurrency = currencyId,
            CapturedBy = capturedBy.Left(20),
            ReceiptDate = valueDate,
            Days2Clear = 0,
            CostOfUnits = -amount,
            GrossAmountReceived = -amount,
            DeductStampDuty = false,
            StanpDutyAmount = 0
        };

        _context.PortfolioContributorAccounts.Add(contributorAccount);

        return _context.SaveChanges() > 0;
    }

    public async Task<BorrowingCalculationDetails> FetchFundingTermCalculations(int dealId, string withdrawalType, decimal withDrawAmount)
    {
        BorrowingCalculationDetails response = new();
        using (var command = _context.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = $"SP_BorrowingTerminationInitiateAPI '{dealId}','{withdrawalType}','{withDrawAmount}'";
            await _context.Database.OpenConnectionAsync();
            _context.Database.SetCommandTimeout(60000);
            var data = new DataTable();
            using (var result = await command.ExecuteReaderAsync())
            {
                data.Load(result);
                var datarows = data.AsEnumerable();
                response = datarows.Select(model =>
               new BorrowingCalculationDetails()
               {
                   PrincipalBalance = model.Field<decimal>("PrincipalBalance"),
                   InterestBalance = model.Field<decimal>("InterestBalance"),
                   PenaltyAmount = model.Field<decimal>("PenaltyAmount"),
                   SubTotal = model.Field<decimal>("SubTotal"),
                   WithDrawAmount = model.Field<decimal>("WithDrawAmount"),
                   TotalAmount = model.Field<decimal>("TotalAmount"),
               }).FirstOrDefault();
            }
        }
        return response;
    }

    public async Task<int> AddCustomerTransaction(int portfolioId, int idPortfolioContributor,
       DateTime transactionDate, DateTime valueDate, decimal amount, string transactionType,
       string narration, string currencyId, string comment, string capturedBy, bool isMutualFund = true, string application = "API")
    {

        decimal unitValue = 0;
        decimal noOfUnits = 0;
        int idPortfolio = -1;
        string status = "A";

        if (isMutualFund)
        {
            unitValue = Convert.ToDecimal(GetOfferPriceAsAt(portfolioId, valueDate.Date.AddDays(-1), 0));
            var finalUnit = (unitValue == 0 ? 0 : unitValue);
            noOfUnits = finalUnit == 0 ? 0 : (amount / finalUnit);
            status = finalUnit == 0 ? "P" : "V";
            idPortfolio = portfolioId;
        }

        var contributorAccount = new PortfolioContributorAccount()
        {
            IdPortfolioContributor = idPortfolioContributor,
            TransactionDate = transactionDate,
            ValueDate = valueDate.Date,
            Amount = amount,
            UnitValue = unitValue,
            NoOfUnits = noOfUnits,
            TransactionType = transactionType,
            CertficateStatus = "P",
            CertificateUnits = 0,
            Reversed = 0,
            ReversalId = 0,
            Status = status,
            IdPortfolio = idPortfolio,
            CertificateNo = " ",
            PaymentType = "O",
            Comments = comment,// $"Subscription via online portal On:{DateTime.Now},New Client",
            Narration = narration,
            PenaltyCharge = 0,
            UnitsSold = 0,
            IdCurrency = currencyId,
            CapturedBy = capturedBy.Left(20),
            ReceiptDate = valueDate,
            Days2Clear = 0,
            CostOfUnits = amount,
            IdApplication = application,
            IdPortfolioContributorBulkAccount = 0
        };

        _context.PortfolioContributorAccounts.Add(contributorAccount);

        return await _context.SaveChangesAsync() > 0 ? contributorAccount.IdPortfolioContributorAccount : 0;
    }

    public float GetOfferPriceAsAt(int portfolioId, DateTime endDate, decimal price)
    {
        var outParam = new SqlParameter();
        outParam.ParameterName = "@BidPrice";
        outParam.SqlDbType = SqlDbType.Float;
        outParam.Direction = ParameterDirection.Output;
        var unitValue = _context.Database.ExecuteSqlRaw("Moneytor_sp_GetOfferPriceAsAt @ID_Portfolio, @EndDate, @BidPrice OUT",
         new SqlParameter("@ID_Portfolio", portfolioId), new SqlParameter("@EndDate", endDate), outParam);
        var result = !string.IsNullOrWhiteSpace(outParam.Value.ToString()) ? outParam.Value.ToString() : "0";
        return float.Parse(result);
    }

    public async Task<bool> MutualFundBuySellApproval(int ID_Portfolio, string cType, string LoginID,
        int ID_PortfolioContributorAccount, string GetBankAccount, DateTime GetSingleDate)
    {
        var spName = "MutualFund_sp_BuySell_Approval";

        bool response = false;
        _context.Database.SetCommandTimeout(60000);
        int result = await _context.Database.ExecuteSqlRawAsync($"{spName} @ID_Portfolio,@cType,@LoginID,@ID_PortfolioContributorAccount," +
       $"@GetBankAccount,@GetSingleDate",
    new SqlParameter("@ID_Portfolio", ID_Portfolio),
       new SqlParameter("@cType", cType),
       new SqlParameter("@LoginID", LoginID),
       new SqlParameter("@ID_PortfolioContributorAccount", ID_PortfolioContributorAccount),
        new SqlParameter("@GetBankAccount", GetBankAccount),
         new SqlParameter("@GetSingleDate", GetSingleDate));

        response = true;
        return response;
    }

    public async Task<PortfolioGroup> FetchPortfolioGroup(int idPortfolioGroup)
    {
        return await _context.PortfolioGroups.AsNoTracking().FirstOrDefaultAsync(x => x.IdPortfolioGroup == idPortfolioGroup);
    }

    public async Task<decimal> GetPortfolioBalance(int portfolioId, int portfolioContributor)
    {
        var spName = "Contributor_sp_GetContributorCost";
        var costBalanceParam = new SqlParameter()
        {
            ParameterName = "@CostBalance",
            Direction = System.Data.ParameterDirection.Output,
            SqlDbType = System.Data.SqlDbType.Decimal
        };
        _context.Database.SetCommandTimeout(60000);
        _context.Database.SetCommandTimeout(60000);
        await _context.Database.ExecuteSqlRawAsync($"{spName} @ID_Portfolio, @ID_PortfolioContributor, @CostBalance OUT",
         new SqlParameter("@ID_Portfolio", portfolioId), new SqlParameter("@ID_PortfolioContributor", portfolioContributor), costBalanceParam);
        var result = !string.IsNullOrWhiteSpace(costBalanceParam.Value.ToString()) ? costBalanceParam.Value.ToString() : "0";
        return decimal.Parse(result);
    }

    public IQueryable<TransactionViewModel> FetchClientTransactionsByUCIDAndFundId(int ucid, int fundId)
    {
        return (from PCA in _context.PortfolioContributorAccounts.AsNoTracking()
                join P in _context.Portfolios.AsNoTracking() on PCA.IdPortfolio equals P.IdPortfolio
                join PC in _context.PortfolioContributors on PCA.IdPortfolioContributor equals PC.IdPortfolioContributor
                where PC.Ucid == ucid && P.IdPortfolio == fundId
                select new TransactionViewModel
                {
                    transactionId = PCA.IdPortfolioContributorAccount,
                    portfolioId = PCA.IdPortfolio.Value,
                    amount = PCA.Amount.Value,
                    portfolioName = P.Portfolio1,
                    transactionDescription = PCA.Narration,
                    transactionType = PCA.TransactionType == "s" ? "Subscription" : "Redemption",
                    transDate = PCA.TransactionDate.Value,
                    valueDate = PCA.ValueDate.Value,
                    id_portcontributor = PCA.IdPortfolioContributor.Value
                }).AsNoTracking();
    }

    public async Task<DateTime> GetLastValuationDate(int portfolioId)
    {
        var valuations = await _context.PortfolioValuationHistories.AsNoTracking().Where(x => x.IdPortfolio == portfolioId).AsNoTracking().OrderByDescending(x => x.ValuationDate)
            .Select(x => x.ValuationDate).FirstOrDefaultAsync();

        return valuations.HasValue ? valuations.Value : DateTime.Now;

    }

    public async Task<float> GetBidPriceAsAt(int portfolioId, DateTime endDate, decimal price = 0)
    {
        var spName = "Moneytor_sp_GetBidPriceAsAt";
        var bidPriceParam = new SqlParameter()
        {
            ParameterName = "@BidPrice",
            Direction = System.Data.ParameterDirection.Output,
            SqlDbType = System.Data.SqlDbType.Float
        };

        await _context.Database.ExecuteSqlRawAsync($"{spName} @ID_Portfolio, @EndDate, @BidPrice OUT",
          new SqlParameter("@ID_Portfolio", portfolioId), new SqlParameter("@EndDate", endDate), bidPriceParam);
        var result = !string.IsNullOrWhiteSpace(bidPriceParam.Value.ToString()) ? bidPriceParam.Value.ToString() : "0";
        return float.Parse(result);
    }

    public void DeleteTempRedemptionRequest(int portfolioId, int customerId)
    {
        var targetData = _context.TmpRedemptionRequests.
            Where(x => x.PortfolioId == portfolioId && x.PorfolioContributorId == customerId);

        if (targetData.Any())
        {
            _context.TmpRedemptionRequests.RemoveRange(targetData);
            _context.SaveChanges();
        }
    }

    public async Task<List<RedemptionViewModel>> AutoRedemption(int ID_PortfolioContributor, int ID_Portfolio, DateTime SalesDate, decimal GrsQty2Sell, bool RedeemPlusProfit, bool WaivePenalTy)
    {
        string spName = "MutualFund_sp_AutoRedemption";

        var _spContext = _context.LoadStoredProc(spName)
                                    .WithSqlParam(
                                (nameof(ID_PortfolioContributor), ID_PortfolioContributor),
                                (nameof(ID_Portfolio), ID_Portfolio),
                                (nameof(SalesDate), SalesDate),
                                (nameof(GrsQty2Sell), GrsQty2Sell),
                                (nameof(RedeemPlusProfit), RedeemPlusProfit),
                                (nameof(WaivePenalTy), WaivePenalTy)
                                );

        return await _spContext.ExecuteStoreProcedure<RedemptionViewModel>();
    }

    public bool InsertTempRedemptionRequest(List<RedemptionViewModel> requestModel)
    {
        var model = requestModel.Select(x => new TmpRedemptionRequest()
        {
            Avcamt = x.AVCAmt,
            Avcunit = x.AVCUnit,
            CertificateNo = x.CertificateNo,
            CostOfUnits = x.CostOfUnits,
            EmployeeAmt = x.EmployeeAmt,
            EmployerAmt = x.EmployerAmt,
            IdredemptionContributorAccount = x.ID_RedemptionContributorAccount,
            NetSettlement = x.NetSettlement,
            NoOfUnits = x.NoOfUnits,
            OfferPrice = x.OfferPrice,
            PenaltyAmount = x.PenaltyAmount,
            PorfolioContributorId = x.ID_PorfolioContributor,
            PortfolioId = x.ID_Portfolio,
            Posted = x.Posted,
            SalesValue = x.SalesValue,
            WaivePenalty = x.WaivePenalty
        }).ToList();

        _context.TmpRedemptionRequests.AddRange(model);

        return _context.SaveChanges() > 0;
    }

    public IQueryable<TransactionViewModel> FetchClientTransactions(int ucid, int fundId)
    {
        return (from PCA in _context.PortfolioContributorAccounts.AsNoTracking()
                join P in _context.Portfolios.AsNoTracking() on PCA.IdPortfolio equals P.IdPortfolio
                join PC in _context.PortfolioContributors on PCA.IdPortfolioContributor equals PC.IdPortfolioContributor
                where PC.Ucid == ucid
                select new TransactionViewModel
                {
                    transactionId = PCA.IdPortfolioContributorAccount,
                    portfolioId = PCA.IdPortfolio.Value,
                    amount = PCA.Amount.Value,
                    portfolioName = P.Portfolio1,
                    transactionDescription = PCA.Narration,
                    transactionType = PCA.TransactionType,
                    transDate = PCA.TransactionDate.Value,
                    valueDate = PCA.ValueDate.Value,
                    id_portcontributor = PCA.IdPortfolioContributor.Value,
                    status = PCA.Status
                }).AsNoTracking();
    }

    public async Task<decimal> AddRedemptionRequest(int portfolioId, int portfolioContributorId)
    {
        var redemptionList = _context.TmpRedemptionRequests.
             Where(x => x.PortfolioId == portfolioId && x.PorfolioContributorId == portfolioContributorId)
             .ToList();

        //if (!redemptionList.Any()) return Task.FromResult<decimal>(0);

        var amountToRedeem = redemptionList.Sum(x => x.NetSettlement);
        var totalNoOfUnits = redemptionList.Sum(x => x.NoOfUnits);
        var narration = _context.PortfolioContributors.Where(x => x.IdPortfolioContributor == portfolioContributorId).Select(x => x.FullName).FirstOrDefault();
        var unitValue = redemptionList.FirstOrDefault().OfferPrice;
        var costOfUnit = redemptionList.Sum(x => x.CostOfUnits);
        var valuationDate = _context.Portfolios.Where(x => x.IdPortfolio == portfolioId)
            .Select(p => p.ValuationDate).FirstOrDefault();

        var contributorAccount = new PortfolioContributorAccount()
        {
            TransactionDate = DateTime.Now,
            IdPortfolioContributor = portfolioContributorId,
            Amount = amountToRedeem,
            ReceiptDate = DateTime.Now,
            Days2Clear = 0,
            VoucherNo = string.Empty,
            IdBank = string.Empty,
            IdBankAccount = string.Empty,
            CertificateUnits = 0,
            TransactionType = "R",
            PaymentType = "A",
            ValueDate = valuationDate,
            ChequeNo = string.Empty,
            ReversalId = 0,
            Reversed = 0,
            Status = "P",
            CertficateStatus = "P",
            IdPortfolio = portfolioId,
            PenaltyCharge = 0,
            UnitValue = unitValue,
            NoOfUnits = totalNoOfUnits,
            Narration = narration,
            IdPortfolioContributorBulkAccount = 0,
            IdImpPrtContributoAccount = 0,
            UniqueId = 0,
            IncentiveDueNow = 0,
            Exported = false,
            CostOfUnits = costOfUnit,
            BankBranchName = string.Empty,
            AccountNo = string.Empty,
            CalculateRebate = false,
            LockInDays = 0,
            GrossAmountReceived = 0,
            DeductStampDuty = false,
            StanpDutyAmount = 0,
            PortfolioDirectInvestment = false,
            RedeemPlusProfit = true,
            Comments = $"Captured From API On {System.DateTime.Now} by {narration} {Environment.NewLine} =========================== {Environment.NewLine}",
            CapturedBy = "API",
        };

        _context.PortfolioContributorAccounts.Add(contributorAccount);

        _context.SaveChanges();

        var contributorRedemption = redemptionList.Select(item => new PortfolioContributorRedemption()
        {
            CertificateNo = item.CertificateNo,
            CostOfUnits = item.CostOfUnits,
            IdPorfolioContributor = item.PorfolioContributorId,
            IdPortfolio = item.PortfolioId,
            NoOfUnits = item.NoOfUnits,
            IdPortfolioContributorAccount = contributorAccount.IdPortfolioContributorAccount,
            IdRedemptionContributorAccount = item.IdredemptionContributorAccount,
            NetSettlement = item.NetSettlement,
            OfferPrice = unitValue,
            PenaltyAmount = item.PenaltyAmount,
            Posted = false,
            SalesValue = item.SalesValue,
            WaivePenalty = false
        }).ToList();

        await _context.PortfolioContributorRedemptions.AddRangeAsync(contributorRedemption);

        _context.SaveChanges();

        return amountToRedeem ?? 0m;

    }

    public async Task<bool> AddExistingClientOrder(ExistingClientOrderModel model)
    {
        var _order = new ExistingClientOrder()
        {
            Amount = model.amount,
            IdCurrency = model.currencyId,
            IdPortfolio = model.portfolioId,
            TransactionDate = DateTime.Now,
            Ucid = model.ucid,
            TransactionReference = model.tranxRef,
            TransactionStatus = false,
            Tenor = model.tenor
        };

        _context.ExistingClientOrders.Add(_order);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> AddExistingClientWalletOrder(WalletTransactionModel model)
    {
        var _order = new WalletTransaction()
        {
            Amount = model.amount,
            IdCurrency = model.currencyId,
            TransactionDate = DateTime.Now,
            Ucid = model.ucid,
            TransactionReference = model.tranxRef,
            TransactionStatus = "P"
        };

        _context.WalletTransactions.Add(_order);

        return await _context.SaveChangesAsync() > 0;
    }

    public ExistingClientOrder GetExistingClientOrder(string trasactionRef)
    {
        return _context.ExistingClientOrders.AsNoTracking().Where(x => x.TransactionReference == trasactionRef).FirstOrDefault();
    }
    public WalletTransaction GetExistingClientWalletOrder(string trasactionRef)
    {
        return _context.WalletTransactions.AsNoTracking().Where(x => x.TransactionReference == trasactionRef).FirstOrDefault();
    }

    public async Task<bool> UpdateExistingClientOrder(string trasactionRef)
    {
        var targetOrder = await _context.ExistingClientOrders.FirstOrDefaultAsync(x => x.TransactionReference == trasactionRef);

        if (targetOrder != null)
        {
            targetOrder.TransactionStatus = true;
            _context.SaveChanges();

        }

        return true;
    }

    public async Task<bool> UpdateExistingClientWalletOrder(string trasactionRef)
    {
        var targetOrder = await _context.WalletTransactions.FirstOrDefaultAsync(x => x.TransactionReference == trasactionRef);

        if (targetOrder != null)
        {
            targetOrder.TransactionStatus = "A";
            _context.SaveChanges();

        }

        return true;
    }

    public IQueryable<TransactionViewModel> FetchClientCashTransactions(int ucid)
    {
        return (from PCA in _context.PortfolioContributorAccounts.AsNoTracking()
                join PC in _context.PortfolioContributors.AsNoTracking()
                on PCA.IdPortfolioContributor equals PC.IdPortfolioContributor
                where PC.Ucid == ucid
                where PCA.IdPortfolio == -1
                where PCA.Status == "A"
                select new TransactionViewModel
                {
                    transactionId = PCA.IdPortfolioContributorAccount,
                    portfolioId = PCA.IdPortfolio.Value,
                    amount = PCA.Amount.Value,
                    stramount = PCA.Amount.Value.ToString("#,##0.00"),
                    transactionDescription = PCA.Narration,
                    transactionType = PCA.TransactionType.ToLower() == "s" || PCA.TransactionType.ToLower() == "b" ? "Subscription" : "Redemption",
                    transDate = PCA.TransactionDate.Value,
                    valueDate = PCA.ValueDate.Value,
                    id_portcontributor = PCA.IdPortfolioContributor.Value,
                    status = PCA.Status,
                    strtransDate = PCA.TransactionDate.Value.ToString("dd-MMM-yyyy"),
                    strvalueDate = PCA.ValueDate.Value.ToString("dd-MMM-yyyy"),
                    paymentType = PCA.PaymentType,
                    tranType = PCA.TransactionType.ToLower()
                }).OrderByDescending(x => x.transDate).AsNoTracking();
    }

    public IQueryable<RedemptionHistoryViewModel> ListRedemptionHistories()
    {
        return (from PC in _context.PortfolioContributors.AsNoTracking()
                join PCA in _context.PortfolioContributorAccounts.AsNoTracking()
                on PC.IdPortfolioContributor equals PCA.IdPortfolioContributor
                join P in _context.Portfolios.AsNoTracking() on PCA.IdPortfolio equals P.IdPortfolio
                join PCR in _context.PortfolioContributorRedemptions.AsNoTracking()
                on PCA.IdPortfolioContributorAccount equals PCR.IdPortfolioContributorAccount
                select new RedemptionHistoryViewModel()
                {
                    ucId = PC.Ucid.Value,
                    portfolioId = P.IdPortfolio,
                    description = PCA.Narration,
                    netSettlement = PCR.NetSettlement.HasValue ? PCR.NetSettlement.Value : 0,
                    noOfUnits = PCR.NoOfUnits.HasValue ? PCR.NoOfUnits.Value : 0,
                    offerPrice = PCR.OfferPrice.HasValue ? PCR.OfferPrice.Value : 0,
                    penaltyAmount = PCR.PenaltyAmount.HasValue ? PCR.PenaltyAmount.Value : 0,
                    portcontributorId = PCR.IdPorfolioContributor.Value,
                    portfolioContributorAccountId = PCR.IdPortfolioContributorAccount.Value,
                    portfolioName = P.Portfolio1,
                    salesValue = PCR.SalesValue.HasValue ? PCR.SalesValue.Value : 0,
                    transactionId = PCR.IdRedemptionContributorAccount.Value,
                    transDate = PCA.TransactionDate.HasValue ? PCA.TransactionDate.Value : DateTime.Now,
                    status = PCA.Status,
                }).AsNoTracking();

    }

    public async Task<List<int>> ListClientPortfolioContributorIds(int uciId)
    {
        return await _context.PortfolioContributors.AsNoTracking().Where(x => x.Ucid == uciId).Select(x => x.IdPortfolioContributor).ToListAsync();
    }

    public async Task<List<PublicPortfolioViewModel>> FetchPublicPortfolios(string fundtype = null)
    {
        var cmdText = "SELECT p.Portfolio portfolioName,op.ID_BorrowType borrowTypeId, op.ID_Portfolio portfolioId,op.[Description] portfolioDescription,op.PortfolioImage iconUrl,op.MinSubAmount minSubAmount, " +
            "ISNULL(p.UnitBased,0) unitBased, p.ID_Currency currencyId,p.OfferPrice, p.StableVAV stableNAV, op.ProductType FROM OnlinePortfolio op JOIN Portfolio p ON p.ID_Portfolio =op.ID_Portfolio";

        if (!string.IsNullOrWhiteSpace(fundtype))
        {
            cmdText += $" WHERE op.ProductType='{fundtype}'";
        }

        var _commandContext = _context.LoadSqlQuery(cmdText);

        var _commandResult = await _commandContext.ExecuteStoreProcedure<PublicPortfolioViewModel>();

        return _commandResult;
    }

    public IQueryable<CustomerActiveDealsModel> GetCustomersActiveFixedDepositDeals(int portfolioContributorId)
    {
        return _context.BorrowMasters.AsNoTracking().Where(x => x.IdPortfolioContributor == portfolioContributorId && x.Status == "A").Select(x => new CustomerActiveDealsModel()
        {
            DealId = x.IdBorrowMaster,
            Tenor = x.NoOfDays ?? 0,
            MaturityDate = x.MaturityDate.HasValue ? x.MaturityDate.Value.ToString("dd/MM/yyyy") : "",
            Amount = x.BorrowAmount ?? 0,
        });
    }

    public IQueryable<BorrowTerminateDetailModel> GetCustomerBorrowTerminateDetail(int terminateId)
    {
        return _context.BorrowTerminates.AsNoTracking().Where(x => x.IdBorrowTerminate == terminateId).Select(x => new BorrowTerminateDetailModel()
        {
            DealId = x.IdBorrowMaster ?? 0,
            Principal = x.Principal ?? 0,
            PenaltyAmount = x.Penalty2Duduct ?? 0,
            TerminateId = x.IdBorrowTerminate,
            Interest = x.InterestEarned ?? 0,
        });
    }

    public async Task ApproveTermination(int terminateId, string postedBy = "Self")
    {
        string spName = "Borrowing_sp_DealTermination_Approval";
        var _spContext = _context.LoadStoredProc(spName)
                                    .WithSqlParam(("ID_BorrowTerminate", terminateId), ("PostedBy", postedBy));
        _spContext.CommandTimeout = 6000;
        var result = await _spContext.ExecuteStoreProcedure<string>();
    }

    public async Task<BorrowTerminateInitialModel> InitializeBorrowTerminate(int dealId, DateTime transDate)
    {

        var spName = "Borrowing_sp_InitiateTermination";
        var terminationId = new SqlParameter()
        {
            ParameterName = "@ID_BorrowTermination",
            Direction = System.Data.ParameterDirection.Output,
            SqlDbType = System.Data.SqlDbType.Int
        };

        var errorMessage = new SqlParameter()
        {
            ParameterName = "@ErrMessage",
            Direction = System.Data.ParameterDirection.Output,
            SqlDbType = System.Data.SqlDbType.VarChar,
            Size = 200
        };

        await _context.Database.ExecuteSqlRawAsync($"{spName} @ID_BorrowMaster, @TerminationDate,@ErrMessage OUT, @ID_BorrowTermination OUT",
          new SqlParameter("@ID_BorrowMaster", dealId),
          new SqlParameter("@TerminationDate", transDate.Date),
          errorMessage,
          terminationId);
        var dealIdResponse = !string.IsNullOrWhiteSpace(terminationId.Value.ToString()) ? terminationId.Value.ToString() : "0";
        var errorMessageResponse = !string.IsNullOrWhiteSpace(errorMessage.Value.ToString()) ? errorMessage.Value.ToString() : "0";

        var model = new BorrowTerminateInitialModel()
        {
            DealId = int.Parse(dealIdResponse),
            ErrorMessage = errorMessageResponse
        };
        return model;
    }
}
