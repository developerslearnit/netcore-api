using IbsRestApi.Domain.Interfaces;
using IbsRestApi.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace IbsRestApi.Domain.Services;

public class AppService : IAppService
{
    #region DbContext Private Fields
    private readonly MdmContext _context;
    private readonly iMoneytorContext _moneytorContext;
    private readonly SecureContext _secureContext;
    private readonly DmsMoneyBookContext _dmsMoneybookContext;
    private readonly IMemoryCache _cache;
    private readonly IConfiguration _config;
    IWebHostEnvironment _env;
    #endregion

    #region Services Interfaces Private Fields
    private IAuthService _authService;
    private ISetupService _setupService;
    private IMdmService _mdmService;
    private IPortfolioService _portfolioSerice;
    private ISettingsService _settingsService;
    private ICashManagementService _cashManagementService;
    private IFileStorageService _fileStorageService;
    private IKycService _kycService;
    #endregion

    public AppService(MdmContext context, iMoneytorContext moneytorContext, SecureContext secureContext, IMemoryCache cache, IConfiguration config, IWebHostEnvironment env, DmsMoneyBookContext dmsMoneybookContext)
    {
        _context = context;
        _moneytorContext = moneytorContext;
        _secureContext = secureContext;
        _cache = cache;
        _config = config;
        _env = env;
        _dmsMoneybookContext = dmsMoneybookContext;
    }


    public IAuthService Auth {
        get {
            if (_authService == null)
            {
                _authService = new AuthService(_context);
            }

            return _authService;
        }

    }

    public ISetupService SetupService {
        get {
            if (_setupService == null)
            {
                _setupService = new SetupService(_moneytorContext);
            }

            return _setupService;
        }
    }

    public IMdmService MdmService {
        get {
            if (_mdmService == null)
            {
                _mdmService = new MdmService(_context);
            }

            return _mdmService;
        }
    }

    public IPortfolioService PortfolioService {
        get {
            if (_portfolioSerice == null)
            {
                _portfolioSerice = new PortfolioService(_moneytorContext, _context);
            }

            return _portfolioSerice;
        }
    }

    public ISettingsService SettingsService {
        get {
            if (_settingsService == null)
            {
                _settingsService = new SettingsService(_secureContext, _cache);
            }

            return _settingsService;
        }
    }

    public ICashManagementService CashManagementService {
        get {
            if (_cashManagementService == null)
            {
                _cashManagementService = new CashManagementService(_moneytorContext);
            }

            return _cashManagementService;
        }
    }

    public IFileStorageService FileStorageService {
        get {
            if (_fileStorageService == null)
            {
                _fileStorageService = new FileStorageService(_config, _env);
            }

            return _fileStorageService;
        }
    }

    public IKycService KycService {
        get {
            if (_kycService == null)
            {
                _kycService = new KycService(_dmsMoneybookContext, _context);
            }

            return _kycService;
        }
    }
}
