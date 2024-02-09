using IbsRestApi.Application.CommonModels;
using IbsRestApi.Common;
using IbsRestApi.Domain.Interfaces;
using IbsRestApi.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Primitives;

namespace IbsRestApi.Api.Helpers;


public interface IConnectionStringHelper
{
    string GetConnectionString();
}

public class ConnectionStringHelper//: IConnectionStringHelper
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    BranchService _branchService;
    
    public ConnectionStringHelper()
    {
        _httpContextAccessor = new HttpContextAccessor();
       // _branchService = new BranchService();
        
    }

    //public string DbConnectionString { get { return GetConnectionString(); } }

    public string GetConnectionStringss()
    {

        //var selectedCompany = _httpContextAccessor.HttpContext.Request.Headers[AppConstants.APIKEY_BRANCH];

        //if (_httpContextAccessor.HttpContext == null) return string.Empty;

        //if (!_httpContextAccessor.HttpContext.Request.Headers.TryGetValue(AppConstants.APIKEY_BRANCH, out var selectedCompany))
        //{
        //    return string.Empty;
        //}

        //var initialConnectionString = "Data Source=13.72.110.60;Initial Catalog=Moneytor_v10_AAML;User ID=ibs;Password=vaug;Encrypt=False;TrustServerCertificate=False";

        //if (StringValues.IsNullOrEmpty(selectedCompany)) return string.Empty;

        //var selectedBranch = _branchService.GetSeletectedBranch(Guid.Parse(selectedCompany.FirstOrDefault().ToString()));

        //var dbServerName = selectedBranch.ServerName;
        //var dbUserName = EncryptionAlg.DecryptStringAES(selectedBranch.DbUsername);
        //var dbPassword = EncryptionAlg.DecryptStringAES(selectedBranch.DbPassword);

        //var dbName = selectedBranch.IMoneytorDbName;


        //var connectionBuilder = new SqlConnectionStringBuilder(initialConnectionString);

        //connectionBuilder.DataSource = dbServerName;
        //connectionBuilder.InitialCatalog = dbName;
        //connectionBuilder.UserID = dbUserName;
        //connectionBuilder.Password = dbPassword;

        //return connectionBuilder.ConnectionString;
        return string.Empty;
    }
}
