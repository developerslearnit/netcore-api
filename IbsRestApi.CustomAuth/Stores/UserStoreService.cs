using Dapper;
using IbsRestApi.Entities.IbsMdm;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;

namespace IbsRestApi.CustomAuth.Stores;

public class UserStoreService
{
    private readonly SqlConnection _connection;
    public UserStoreService(SqlConnection connection)
    {
        _connection = connection;
    }

    public async Task<IdentityResult> CreateAsync(OnlineUserAccount user)
    {
        string sql = "INSERT INTO dbo.OnlineUserAccount (AccountCode,Password, PasswordSalt, UCID, IsActive,DateCreated,Email,LoginPin)" +
            "VALUES (@AccountCode,@Password, @PasswordSalt, @UCID, @IsActive,@DateCreated, @Email,@LoginPin)";

        int rows = await _connection.ExecuteAsync(sql, new {
            user.AccountCode,
            user.Password,
            user.PasswordSalt,
            user.Ucid,
            user.IsActive,
            user.DateCreated,
            user.Email,
            user.LoginPin
        });

        if (rows > 0)
        {
            return IdentityResult.Success;
        }
        return IdentityResult.Failed(new IdentityError { Description = $"Could not insert user {user.Email}." });
    }


    public async Task<OnlineUserAccount> FindByNameAsync(string userName)
    {
        string sql = "SELECT * " +
                    "FROM dbo.OnlineUserAccount " +
                    "WHERE AccountCode = @AccountCode;";

        return await _connection.QuerySingleOrDefaultAsync<OnlineUserAccount>(sql, new {
            AccountCode = userName
        });
    }


    public async Task<OnlineUserAccount> FindByEmailAsync(string email)
    {
        string sql = "SELECT * " +
                    "FROM dbo.OnlineUserAccount " +
                    "WHERE Email = @email;";

        return await _connection.QuerySingleOrDefaultAsync<OnlineUserAccount>(sql, new {
            Email = email
        });
    }


    public async Task<bool> CheckPasswordHashAsync(string userName, string password)
    {

        var sql = "SELECT Password FROM OnlineUserAccount WHERE AccountCode = @AccountCode";
        var userPassword = await _connection.QuerySingleOrDefaultAsync(sql, new {
            AccountCode = userName
        });

        if (userPassword == null) return false;

        return userPassword == password;

    }

    public async Task<OnlineUserAccount> FindByIdAsync(int userId)
    {
        string sql = "SELECT * " +
                    "FROM dbo.OnlineUserAccount " +
                    "WHERE ID_OnlineUserAccount = @UserId;";

        return await _connection.QuerySingleOrDefaultAsync<OnlineUserAccount>(sql, new {
            UserId = userId
        });
    }
}
