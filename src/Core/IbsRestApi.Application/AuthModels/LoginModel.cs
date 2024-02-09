namespace IbsRestApi.Application.AuthModels;

public class LoginModel
{
    public string userName { get; set; }

    public string password { get; set; }
}

public class ChangePasswordViewModel
{
    public string accountId { get; set; }
    public string oldpassword { get; set; }
    public string newpassword { get; set; }
}
