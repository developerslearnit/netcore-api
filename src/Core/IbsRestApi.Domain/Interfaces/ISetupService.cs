using IbsRestApi.Application.Portfolios;

namespace IbsRestApi.Domain.Interfaces;

public interface ISetupService
{
    Task<List<PortfolioViewModel>> FetchOnlinePortfolios();
    Task<List<TenorModel>> FecthProductTenors(string borrowTypeId);
    Task<List<PublicPortfolioViewModel>> FetchPublicPortfolios(string? fundtype = null);
    Task<List<PublicPortfolioMinViewModel>> FetchPublicPortfoliosMinDetails(string? fundtype = null);
    IEnumerable<ProductViewModel> PortfoliosWithOfferAndBidPrice(List<PublicPortfolioViewModel> model);
}


