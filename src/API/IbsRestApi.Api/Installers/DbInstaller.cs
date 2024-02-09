using IbsRestApi.Api.Helpers;
using IbsRestApi.Application.CommonModels;
using IbsRestApi.Common;
using IbsRestApi.Domain.Services;
using IbsRestApi.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System.Data;

namespace IbsRestApi.Api.Installers;

public class DbInstaller : IInstaller
{
    private ConnectionStringHelper _connectionHelper;

    public DbInstaller()
    {
        _connectionHelper = new ConnectionStringHelper();
    }

    public void InstallServices(WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        var forceBranchNameHeader = builder.Configuration.GetValue<bool>("ForceBranchNameHeader");


        builder.Services.AddDbContext<iMoneytorContext>(((serviceProvider, options) =>
        {
            var httpContext = serviceProvider.GetService<IHttpContextAccessor>().HttpContext;
            var httpRequest = httpContext.Request;

            var selectedBranchConnection = builder.Configuration.GetSection("DBConnections:iMoneytorConnection").Value;

          

            if (httpRequest == null) selectedBranchConnection = builder.Configuration.GetSection("DBConnections:iMoneytorConnection").Value;

            if (httpRequest.Headers.TryGetValue(AppConstants.APIKEY_BRANCH, out var selectedCompany))
            {

                var initialConnectionString = "Data Source=13.72.110.60;Initial Catalog=Moneytor_v10_AAML;User ID=ibs;Password=vaug;Encrypt=False;TrustServerCertificate=False";
                var secureConnection = builder.Configuration.GetSection("DBConnections:SecureConnection").Value;
                var _branchService = new BranchService(secureConnection);

                if (selectedCompany.FirstOrDefault() != null)
                {
                    var branchId = selectedCompany.FirstOrDefault().ToString();

                    if (Guid.TryParse(branchId, out Guid idBranch))
                    {
                        var selectedBranch = _branchService.GetSeletectedBranch(idBranch);


                        if (selectedBranch != null)
                        {
                            var dbServerName = selectedBranch.ServerName;
                            var dbUserName = EncryptionAlg.DecryptStringAES(selectedBranch.DbUsername);
                            var dbPassword = EncryptionAlg.DecryptStringAES(selectedBranch.DbPassword);

                            var dbName = selectedBranch.IMoneytorDbName;


                            var connectionBuilder = new SqlConnectionStringBuilder(initialConnectionString);

                            connectionBuilder.DataSource = dbServerName;
                            connectionBuilder.InitialCatalog = dbName;
                            connectionBuilder.UserID = dbUserName;
                            connectionBuilder.Password = dbPassword;
                            selectedBranchConnection = connectionBuilder.ConnectionString;
                        }
                    }
                }
              
            }

            options.UseSqlServer(selectedBranchConnection);
        }));





        builder.Services.AddDbContext<MdmContext>(options =>
                  options.UseSqlServer(builder.Configuration.GetSection("DBConnections:IbsMdmConnection").Value,
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 10,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null
                            );
                    }));



        builder.Services.AddDbContext<DmsMoneyBookContext>(options =>
                 options.UseSqlServer(builder.Configuration.GetSection("DBConnections:DmsMoneyBookConnection").Value,
                   sqlServerOptionsAction: sqlOptions =>
                   {
                       sqlOptions.EnableRetryOnFailure(
                           maxRetryCount: 10,
                           maxRetryDelay: TimeSpan.FromSeconds(30),
                           errorNumbersToAdd: null
                           );
                   }));

        builder.Services.AddDbContext<IbsApiContext>(options =>
                 options.UseSqlServer(builder.Configuration.GetSection("DBConnections:APILogConnection").Value,
                   sqlServerOptionsAction: sqlOptions =>
                   {
                       sqlOptions.EnableRetryOnFailure(
                           maxRetryCount: 10,
                           maxRetryDelay: TimeSpan.FromSeconds(30),
                           errorNumbersToAdd: null
                           );
                   }));


        builder.Services.AddScoped<IDbConnection, SqlConnection>(db =>
            new SqlConnection(builder.Configuration.GetSection("DBConnections:IbsMdmConnection").Value));
    }
}
