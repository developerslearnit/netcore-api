namespace IbsRestApi.Application.AuthModels;
public class EmailOTPModel
{
    public string email { get; set; }
    public string code { get; set; } = string.Empty;
}

public class TokenValidationResponse
{
    public bool HasError { get; set; } =false;
    public string ErrorMessage { get; set; } = string.Empty;
}
