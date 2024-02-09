namespace IbsRestApi.Application.IbsMdm;

public class BasicRegistrationModel
{
    public string email { get; set; }
    public string password { get; set; } = "";
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string otherNames { get; set; }
    public string phoneNumber { get; set; }
    public string bvn { get; set; }
    public bool accept_terms { get; set; }
    public string birth_date { get; set; }

}

public class ClientFullModel
{
    public string email { get; set; }
    public int client_unique_ref { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string otherNames { get; set; }
    public string phoneNumber { get; set; }
    public string bvn { get; set; }
    public string birth_date { get; set; }
    public string address { get; set; }
    public string profilePictureUrl { get; set; }

    public List<IbsPeopleBankAccountModel> banks { get; set; }
    public List<IbsPeopleMinorModel> minors { get; set; }
    public List<IbsPeopleNextOfKinModel> nextOfKin { get; set; }
}
