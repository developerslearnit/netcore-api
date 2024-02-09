namespace IbsRestApi.Application.AuthModels;

public enum LoginStatus
{
    Failed = 0,
    Success = 1,
    Deactivated = 2,
    AccountLocked = 3,
}

public class LoginResult
{
    public LoginStatus status { get; set; }
    public bool hasError { get; set; } = false;
    public string message { get; set; }
    public bool requiredPasswordChange { get; set; }
    public UserModel user { get; set; }
    
}
