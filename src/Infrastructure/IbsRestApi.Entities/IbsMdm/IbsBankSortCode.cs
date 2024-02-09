namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsBankSortCode
{
    public int IdBankSortCode { get; set; }
    public string? IdBank { get; set; }
    public string? SortCode { get; set; }
    public string? BranchName { get; set; }

    public virtual IbsBank? IdBankNavigation { get; set; }
}
