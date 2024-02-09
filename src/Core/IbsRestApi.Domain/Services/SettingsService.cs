using IbsRestApi.Application.AuthModels;
using IbsRestApi.Application.IbsMdm;
using IbsRestApi.Application.WxIbsSecure;
using IbsRestApi.Common;
using IbsRestApi.Domain.Interfaces;
using IbsRestApi.Entities.Secure;
using IbsRestApi.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System.Collections.Specialized;

namespace IbsRestApi.Domain.Services;


public class BranchService
{
    private SecureContext _secureContext;
    public BranchService( string connectionStr)
    {

        var optionsBuilder = new DbContextOptionsBuilder<SecureContext>();
        optionsBuilder.UseSqlServer(connectionStr);
        _secureContext = new SecureContext(optionsBuilder.Options);

    }

    public BranchModel GetSeletectedBranch(Guid branchId)
    {
        return _secureContext.AppBranches.AsNoTracking().Where(x => x.IdBranches == branchId).Select(x => new BranchModel()
        {
            BranchId = x.IdBranches,
            BranchName = x.BranchName,
            DbPassword = x.DbPassword,
            DbUsername = x.DbUsername,
            IMoneytorDbName = x.DatabaseName,
            MoneyBookDbName = x.MoneyBookDatabase,
            ServerName = x.ServerName

        }).FirstOrDefault();
    }
}

public class SettingsService : ISettingsService
{
    private readonly SecureContext _context;
    private readonly IMemoryCache _cache;

    public SettingsService(SecureContext context, IMemoryCache cache)
    {
        _context = context;
        _cache = cache;
    }

    public void LoadAppSetting()
    {

        if (!_cache.TryGetValue("ConfigSettings", out NameValueCollection cachedSettings))
        {
            var settings = _context.AppConfigSettings.AsNoTracking().ToList();
            var settingsCollection = new NameValueCollection();

            foreach (var item in settings)
            {
                settingsCollection.Add(item.ConfigKey, item.ConfigValue);
            }

            cachedSettings = settingsCollection;

            // Set cache options.
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                // Keep in cache for this time, reset time if accessed.
                .SetSlidingExpiration(TimeSpan.FromHours(3));

            //Set the Cache
            _cache.Set("ConfigSettings", cachedSettings, cacheEntryOptions);

        }
    }

    public string GetSetting(string configKey)
    {

        _cache.Remove("ConfigSettings");

        if (!_cache.TryGetValue("ConfigSettings", out NameValueCollection cachedSettings))
        {
            var settings = _context.AppConfigSettings.AsNoTracking().ToList();
            var settingsCollection = new NameValueCollection();

            foreach (var item in settings)
            {
                settingsCollection.Add(item.ConfigKey, item.ConfigValue);
            }

            cachedSettings = settingsCollection;

            // Set cache options.
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                // Keep in cache for this time, reset time if accessed.
                .SetSlidingExpiration(TimeSpan.FromHours(3));

            //Set the Cache
            _cache.Set("ConfigSettings", cachedSettings, cacheEntryOptions);

        }

        var setting = cachedSettings[configKey];

        //var setting = await _context.AppConfigSettings.Where(x => x.ConfigKey == configKey).FirstOrDefaultAsync();

        return setting != null ? setting : string.Empty;
    }

    public SMTPSettingDTO GetSMTPSettings()
    {


        _cache.Remove("SMTPSettings");

        if (!_cache.TryGetValue("SMTPSettings", out SMTPSettingDTO cachedSettings))
        {
            cachedSettings = _context.Smtpsettings.AsNoTracking().Select(m => new SMTPSettingDTO
            {
                MailType = m.MailType,
                SMTPHost = m.Smtphost,
                SMTPPort = m.Smtpport,
                EnableSSL = m.EnableSsl,
                ID = m.Id,
                ID_Application = m.IdApplication,
                ReplyToAddress = m.ReplyToAddress,
                SecureEmail_Always = m.SecureEmailAlways,
                SecureEmail_StartTLS = m.SecureEmailStartTls,
                SenderAddress = m.SenderAddress,
                SenderName = m.SenderName,
                AuthPassWord = m.AuthPassWord,
                AuthUser = m.AuthUser,
                UseSMTP = m.UseSmtp
            }).AsNoTracking().FirstOrDefault();


            // Set cache options.
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                // Keep in cache for this time, reset time if accessed.
                .SetSlidingExpiration(TimeSpan.FromHours(24));

            //Set the Cache
            _cache.Set("SMTPSettings", cachedSettings, cacheEntryOptions);

        }

        return cachedSettings;

    }

    public List<PaymentChannelViewModel> ListPaymentChannels()
    {
        _cache.Remove("paymentChannels");


        if (!_cache.TryGetValue("paymentChannels", out List<PaymentChannelViewModel> paymentChannels))
        {
            paymentChannels = _context.PaymentChannels.AsNoTracking().Where(x => x.Status == true)
            .Select(x => new PaymentChannelViewModel
            {
                ChannelKey = x.ChannelKey,
                ChannelName = x.ChannelName,
                Status = x.Status,
                LivePublicKey = x.LivePublicKey,
                LiveSecretKey = x.LiveSecretKey,
                TestPublicKey = x.TestPublicKey,
                TestSecretKey = x.TestSecretKey,
                ChannelLogo = x.ChannelLogo
            }).AsNoTracking()
            .ToList();

            // Set cache options.
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                // Keep in cache for this time, reset time if accessed.
                .SetSlidingExpiration(TimeSpan.FromHours(24));

            //Set the Cache
            _cache.Set("paymentChannels", paymentChannels, cacheEntryOptions);
        }

        return paymentChannels;

    }

    public void LoadAllPaymentChannels()
    {
        if (!_cache.TryGetValue("paymentChannels", out List<PaymentChannelViewModel> paymentChannels))
        {
            paymentChannels = _context.PaymentChannels.AsNoTracking().Where(x => x.Status == true)
            .Select(x => new PaymentChannelViewModel
            {
                ChannelKey = x.ChannelKey,
                ChannelName = x.ChannelName,
                Status = x.Status,
                LivePublicKey = x.LivePublicKey,
                LiveSecretKey = x.LiveSecretKey,
                TestPublicKey = x.TestPublicKey,
                TestSecretKey = x.TestSecretKey
            }).AsNoTracking()
            .ToList();

            // Set cache options.
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                // Keep in cache for this time, reset time if accessed.
                .SetSlidingExpiration(TimeSpan.FromHours(24));

            //Set the Cache
            _cache.Set("paymentChannels", paymentChannels, cacheEntryOptions);
        }


    }

    public void LoadSMTPSettings()
    {

        if (!_cache.TryGetValue("SMTPSettings", out SMTPSettingDTO cachedSettings))
        {
            cachedSettings = _context.Smtpsettings.AsNoTracking().Select(m => new SMTPSettingDTO
            {
                MailType = m.MailType,
                SMTPHost = m.Smtphost,
                SMTPPort = m.Smtpport,
                EnableSSL = m.EnableSsl,
                ID = m.Id,
                ID_Application = m.IdApplication,
                ReplyToAddress = m.ReplyToAddress,
                SecureEmail_Always = m.SecureEmailAlways,
                SecureEmail_StartTLS = m.SecureEmailStartTls,
                SenderAddress = m.SenderAddress,
                SenderName = m.SenderName,
                AuthPassWord = m.AuthPassWord,
                AuthUser = m.AuthUser,
                UseSMTP = m.UseSmtp
            }).AsNoTracking().FirstOrDefault();


            // Set cache options.
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                // Keep in cache for this time, reset time if accessed.
                .SetSlidingExpiration(TimeSpan.FromHours(24));

            //Set the Cache
            _cache.Set("SMTPSettings", cachedSettings, cacheEntryOptions);

        }

    }


    public void LogApplicationError(ErrorLogViewModel errorModel)
    {
        var appError = new AppExceptionLog()
        {
            ErrorType = errorModel.errorType,
            ErrorSource = errorModel.errorSource,
            ErrorMessage = errorModel.errorMessage,
            LoggedInUser = errorModel.loggedInUser,
            ErrorXml = errorModel.errorXML,
            TimeUtc = DateTime.UtcNow,
            ControllerName = errorModel.controllerName,
            ActionName = errorModel.actionName,
            AreaName = errorModel.areaName
        };

        _context.AppExceptionLogs.Add(appError);
        _context.SaveChanges();
    }

    public void AddSetting(string key, string value)
    {
        var setting = _context.AppConfigSettings.FirstOrDefault(x => x.ConfigKey == key);

        if (setting == null)
        {
            var newSetting = new AppConfigSetting()
            {
                ConfigKey = key,
                ConfigValue = value
            };

            _context.AppConfigSettings.Add(newSetting);

            _context.SaveChanges();
        }
    }

    public void SeedSettings(List<KeyValuePair<string, string>> model)
    {

        foreach (var item in model)
        {
            AddSetting(item.Key, item.Value);
        }
    }

    public BranchModel GetSeletectedBranch(Guid branchId)
    {
        return _context.AppBranches.AsNoTracking().Where(x => x.IdBranches == branchId).Select(x => new BranchModel()
        {
            BranchId = x.IdBranches,
            BranchName = x.BranchName,
            DbPassword = x.DbPassword,
            DbUsername = x.DbUsername,
            IMoneytorDbName = x.DatabaseName,
            MoneyBookDbName = x.MoneyBookDatabase,
            ServerName = x.ServerName

        }).FirstOrDefault();
    }

    public List<BranchModel> GetAllBarnches()
    {
        if (!_cache.TryGetValue("AppBarnches", out List<BranchModel> branches))
        {
            branches = _context.AppBranches.AsNoTracking().Select(x => new BranchModel()
            {
                BranchId = x.IdBranches,
                BranchName = x.BranchName,
                DbPassword = x.DbPassword,
                DbUsername = x.DbUsername,
                IMoneytorDbName = x.DatabaseName,
                MoneyBookDbName = x.MoneyBookDatabase,
                ServerName = x.ServerName

            }).ToList();

            var cacheEntryOptions = new MemoryCacheEntryOptions()
               // Keep in cache for this time, reset time if accessed.
               .SetSlidingExpiration(TimeSpan.FromDays(24));

            //Set the Cache
            _cache.Set("AppBarnches", branches, cacheEntryOptions);

        }

        return branches;
    }


    public async Task<bool> AddEmailToken(string email, string token)
    {
        var newToken = new Otprepository()
        {
            Email = email,
            AccountCode = email,
            Code = token,
            ExpiryDate = DateTime.Now.AddMinutes(10),
            Used = false,
            RequestId = Guid.NewGuid(),
        };

        await _context.Otprepositories.AddAsync(newToken);

        return await _context.SaveChangesAsync() > 0;

    }

    public async Task<TokenValidationResponse> ValidateEmailToken(string email, string token)
    {
        var foundToken = await _context.Otprepositories
            .Where(x => x.Email == email && x.Code == token
            && x.Used==false && x.ExpiryDate > DateTime.Now
            ).FirstOrDefaultAsync();

        if (foundToken == null)
            return new TokenValidationResponse
            {
                HasError = true,
                ErrorMessage = "This token is not valid"
            };

        if (foundToken.Used)
            return new TokenValidationResponse
            {
                HasError = true,
                ErrorMessage = "This token has been used"
            };


        if (foundToken.ExpiryDate < DateTime.Now)
            return new TokenValidationResponse
            {
                HasError = true,
                ErrorMessage = "This token has expired"
            };

        foundToken.Used = true;
        _context.SaveChanges();

        return new TokenValidationResponse
        {
            HasError = false,
            ErrorMessage = "This token is valid"
        };

    }
}
