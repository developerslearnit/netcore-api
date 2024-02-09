namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsBank
{
    public IbsBank()
    {
        IbsBankSortCodes = new HashSet<IbsBankSortCode>();
    }

    public string IdBank { get; set; } = null!;
    public string? BankName { get; set; }
    public string? Address01 { get; set; }
    public string? Address02 { get; set; }
    public string? IdState { get; set; }
    public bool? OpenAccount { get; set; }
    public string? BankGlActNo { get; set; }
    public string? SwitchCode { get; set; }
    public string? BankCode { get; set; }
    public string? HqrsortCode { get; set; }

    public virtual ICollection<IbsBankSortCode> IbsBankSortCodes { get; set; }
}
