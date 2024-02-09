namespace IbsRestApi.Application.IbsMdm;

public class IbsPeopleMinorModel
{
    public int ucid { get; set; }

    public string firstName { get; set; }
    public string lastName { get; set; }
    public string othername { get; set; }

    public string email { get; set; }

    public string mobile_phone { get; set; }

    public string accountNumber { get; set; }

    public string address_line1 { get; set; }

    public string address_line2 { get; set; }

    public string dateOfbirth { get; set; }
    public int parrentUCID { get; set; }
}

public class IbsPeopleMinorResultModel
{
    public int ucid { get; set; }
}

public class IbsPeopleMinorUpdateModel
{
    public int ucid { get; set; }

    public string firstName { get; set; }
    public string lastName { get; set; }
    public string othername { get; set; }

    public string email { get; set; }

    public string mobile_phone { get; set; }

    public string accountNumber { get; set; }

    public string address_line1 { get; set; }

    public string address_line2 { get; set; }

    public string dateOfbirth { get; set; }
    public DateTime dob { get; set; }
    public int client_unique_ref { get; set; }
}

public class UserAvatarModel
{
    public int ucid { get; set; }
    public string avatarUrl { get; set; }
    public string fileType { get; set; } = "Uri";
    public bool hasAvatar { get; set; } = true;
}
