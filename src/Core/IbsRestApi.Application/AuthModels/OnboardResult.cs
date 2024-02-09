namespace IbsRestApi.Application.AuthModels;

public class OnboardResult
{
    public int client_unique_ref { get; set; }
    public string currency { get; set; }
    public string accountId { get; set; }
    public string email { get; set; }
}
