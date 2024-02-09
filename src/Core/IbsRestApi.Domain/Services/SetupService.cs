using IbsRestApi.Application.Portfolios;
using IbsRestApi.Domain.Interfaces;
using IbsRestApi.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using IbsRestApi.Application.Portfolios;

namespace IbsRestApi.Domain.Services;

public class SetupService : ISetupService
{
    private readonly iMoneytorContext _context;

    public SetupService(iMoneytorContext context)
    {
        _context = context;
    }


    public async Task<List<TenorModel>> FecthProductTenors(string borrowTypeId)
    {
        return await _context.BorrowRateTables.Where(x=>x.IdBorrowType == borrowTypeId)
             .Select(x=>new TenorModel
             {
                 Tenor = x.FromTenor.Value
             })
             .Distinct()            
            .ToListAsync();
    }


    public async Task<List<PortfolioViewModel>> FetchOnlinePortfolios()
    {

        return await (from op in _context.OnlinePortfolios
                          join p in _context.Portfolios
                          on op.IdPortfolio equals p.IdPortfolio
                          select new PortfolioViewModel
                          {
                              product_Id = p.IdPortfolio,
                              borrowTypeId = op.ID_BorrowType,
                              minSubAmount = op.MinSubAmount.HasValue ? op.MinSubAmount.Value : 0,
                              product_name = op.PortfolioName,
                              product_type = op.ProductType,
                              currency = p.IdCurrency
                          }).ToListAsync();
    }

    public async Task<List<PublicPortfolioViewModel>> FetchPublicPortfolios(string? fundtype = null)
    {
        var cmdText = "SELECT op.PortfolioName portfolioName, op.ID_Portfolio portfolioId," +
            "op.ID_BorrowType borrowTypeId, op.[Description] portfolioDescription,op.PortfolioImage iconUrl,op.MinSubAmount minSubAmount, " +
            "ISNULL(p.UnitBased,0) unitBased, p.ID_Currency currencyId,p.OfferPrice, p.StableVAV stableNAV, op.ProductType FROM OnlinePortfolio op JOIN Portfolio p ON p.ID_Portfolio =op.ID_Portfolio";

        if (!string.IsNullOrWhiteSpace(fundtype))
        {
            cmdText += $" WHERE op.ProductType='{fundtype}'";
        }

        var _commandContext = _context.LoadSqlQuery(cmdText);

        var _commandResult = await _commandContext.ExecuteStoreProcedure<PublicPortfolioViewModel>();

        return _commandResult;
    }

    public async Task<List<PublicPortfolioMinViewModel>> FetchPublicPortfoliosMinDetails(string? fundtype = null)
    {
        var cmdText = "SELECT p.Portfolio portfolioName, op.ID_Portfolio portfolioId,op.[Description] portfolioDescription,op.MinSubAmount minSubAmount, ISNULL(p.UnitBased,0) unitBased, p.ID_Currency currencyId, op.ProductType FROM OnlinePortfolio op JOIN Portfolio p ON p.ID_Portfolio =op.ID_Portfolio";

        if (!string.IsNullOrWhiteSpace(fundtype))
        {
            cmdText += $" WHERE op.ProductType='{fundtype}'";
        }

        var _commandContext = _context.LoadSqlQuery(cmdText);

        var _commandResult = await _commandContext.ExecuteStoreProcedure<PublicPortfolioMinViewModel>();

        return _commandResult;
    }

    public IEnumerable<ProductViewModel> PortfoliosWithOfferAndBidPrice(List<PublicPortfolioViewModel> model)
    {
        var resultList = new List<ProductViewModel>();

        var endate = DateTime.Now;

        foreach (var item in model)
        {
            float bid = Task.Run(() => GetBidPriceAsAt(item.portfolioId, endate.Date.AddDays(-1))).Result;
            float offer = GetOfferPriceAsAt(item.portfolioId, endate.Date.AddDays(-1));
            decimal yield = 0;

            yield = _context.PortfolioValuationHistories.AsNoTracking().Where(x => x.IdPortfolio == item.portfolioId && x.ValuationDate == endate.Date.AddDays(-1))
                                .OrderByDescending(d => d.ValuationDate)
                                .Select(x => x.DayYield).Take(1).FirstOrDefault() ?? 0;

            var productType = string.IsNullOrWhiteSpace(item.ProductType) ? "" : item.ProductType.ToLower();

            resultList.Add(new ProductViewModel()
            {
                product_Id = item.portfolioId,
                product_name = item.portfolioName,
                bidPrice = productType == "MFUNDS".ToLower() ? bid : 0,
                offerPrice = productType == "MFUNDS".ToLower() ? offer : 0,
                yield = yield,
                isUnitBased = item.unitBased,
                product_type = item.ProductType,
                currency = item.currencyId,
                description = item.portfolioDescription,
                minSubAmount = item.minSubAmount,
                borrowTypeId = item.borrowTypeId,
            });

        }

        return resultList;

    }

    #region Helpers
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

    float GetOfferPriceAsAt(int portfolioId, DateTime endDate)
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
    #endregion
}
