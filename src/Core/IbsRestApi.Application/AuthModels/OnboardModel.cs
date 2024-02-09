namespace IbsRestApi.Application.AuthModels;

public class OnboardModel
{
    public string email { get; set; }
    public string password { get; set; } = "";
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string otherNames { get; set; } = "";
    public string phoneNumber { get; set; }
    public string address { get; set; } = "";
    public string bvn { get; set; } = "";
    public bool accept_terms { get; set; } = true;
    public string birth_date { get; set; }
    public int client_unique_ref { get; set; }

    //More Info
    public string idCountry { get; set; } = "";
    public string title { get; set; } = "";
    public string gender { get; set; } = "";
    public string idState { get; set; } = "";
    public int idOccupation { get; set; }
    public string maritalStatus { get; set; } = "";
    public string sourceOfFund { get; set; } = "";
}
