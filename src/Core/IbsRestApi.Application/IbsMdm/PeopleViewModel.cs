namespace IbsRestApi.Application.IbsMdm;

public class PeopleViewModel
{
    public int ucid { get; set; }

    public string firstName { get; set; }

    public string lastName { get; set; }

    public string otherName { get; set; }

    public string email { get; set; }

    public string phoneNumber { get; set; }

    public string bankCode { get; set; }

    public string accountNumber { get; set; }

    public string Bvn { get; set; }

    public string addressLine1 { get; set; }

    public string addressLine2 { get; set; }

    public string pccNumber { get; set; }

    public DateTime? dateOfBirth { get; set; }
    public string customerType { get; set; }
    public string childFirstName { get; set; }
    public string childLastName { get; set; }
    public string jointAccountName { get; set; }
    public string identifyWithId { get; set; }
    public int occupationId { get; set; }

    //Next Of Kin
    public string nokFirstName { get; set; }
    public string nokLastName { get; set; }
    public string nokEmail { get; set; }
    public string nokAddress { get; set; }
    public string nokPhoneNumber { get; set; }
    public string nokRelationship { get; set; }

    //More Info
    public string idCountry { get; set; }
    public string title { get; set; }
    public string gender { get; set; }
    public string idState { get; set; }
    public string sourceOfFund { get; set; }
    public string maritalStatus { get; set; }
}
