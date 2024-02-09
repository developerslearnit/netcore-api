using IbsRestApi.Api.Helpers;
using IbsRestApi.Communications;
using IbsRestApi.CustomAuth.Stores;
using IbsRestApi.Domain.Interfaces;
using IbsRestApi.Domain.Services;
using IbsRestApi.Entities.IbsMdm;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;

namespace IbsRestApi.Api.Installers;

public class ServiceInstaller : IInstaller
{
    public void InstallServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IUserStore<OnlineUserAccount>, IbsUserStore>();
        builder.Services.AddTransient<IRoleStore<IbsTitle>, IbsRoleStore>();
        builder.Services.AddScoped<IAppService, AppService>();
        builder.Services.AddTransient<SqlConnection>(e => new SqlConnection(builder.Configuration.GetSection("DBConnections:IbsMdmConnection").Value));
        builder.Services.AddTransient<UserStoreService>();
        builder.Services.AddScoped<IMemoryCache, MemoryCache>();
        builder.Services.AddScoped<IMailKitService, MailKitService>();
        builder.Services.AddScoped<IMailSender, MailSender>();
        builder.Services.AddScoped<IAPIHelpers, APIHelpers>();
        builder.Services.AddScoped<IIbsAPIService, IbsAPIService>();
    }
}
