using IbsRestApi.Application.IbsMdm;

namespace IbsRestApi.Application.AuthModels;

public class UserModel
{
    public int client_unique_ref { get; set; }
    public string accountId { get; set; } = "";
    public string firstName { get; set; } = "";
    public string lastName { get; set; } = "";
    public string email { get; set; } = "";
    public string mobilePhone { get; set; } = "";
    public string access_token { get; set; } = "";
    public string refreshToken { get; set; } = "";
    public bool activeStatus { get; set; }
    public bool isLockedOut { get; set; }
    public UserAvatarModel userAvatar { get; set; }
}

public class UserAuthModel
{
    public string userName { get; set; } = "";
    public string password { get; set; } = "";
    public string passwordSalt { get; set; } = "";
}
