namespace IbsRestApi.Application.CommonModels;

public class JWTSettings
{
    public string validIssuer { get; set; }

    public string validAudience { get; set; }

    public int tokenExipration { get; set; }
}
