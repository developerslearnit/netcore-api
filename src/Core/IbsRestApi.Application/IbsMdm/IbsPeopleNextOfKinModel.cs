namespace IbsRestApi.Application.IbsMdm;

public class IbsPeopleNextOfKinModel
{
    public int id { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string otherName { get; set; }
    public string address { get; set; }
    public string phoneNumber { get; set; }
    public string email { get; set; }
    public string relationship { get; set; }
    public int? idRelationship { get; set; }
    public int client_unique_ref { get; set; }
}

public class IbsPeopleNextOfKinResultModel
{
    public int id { get; set; }
}
