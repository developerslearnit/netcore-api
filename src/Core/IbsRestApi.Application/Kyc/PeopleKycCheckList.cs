namespace IbsRestApi.Application.Kyc;
public class PeopleKycCheckList
{
    public int ID_KycCheckList { get; set; }

    public string description { get; set; }

    public bool verified { get; set; }

    public string verifiedText { get; set; }

    public string Submitted { get; set; }

    public string FileExtension { get; set; }
    public int ucid { get; set; }
}
