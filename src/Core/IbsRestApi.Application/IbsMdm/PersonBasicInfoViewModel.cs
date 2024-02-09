namespace IbsRestApi.Application.IbsMdm;

public class PersonBasicInfoViewModel
{
    public int ucid { get; set; }

    public string name { get; set; }

    public string firstName { get; set; }
    public string lastName { get; set; }
    public string Othername { get; set; }

    public string email { get; set; }

    public string mobile_phone { get; set; }

    public string accountNumber { get; set; }

    public string address_line1 { get; set; }

    public string address_line2 { get; set; }

    public DateTime dateOfbirth { get; set; }

    public string PccNumber { get; set; }
    public bool showDate { get; set; }
    public string PhotoImage { get; set; }
    public string ImageExt { get; set; }
    public string bvn { get; set; }
}
