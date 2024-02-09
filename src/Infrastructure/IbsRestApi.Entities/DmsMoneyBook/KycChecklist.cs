namespace IbsRestApi.Entities.DmsMoneyBook;

public partial class KycChecklist
{
    public KycChecklist()
    {
        IbsPeopleKycs = new HashSet<IbsPeopleKyc>();
    }

    public int IdKycCheckList { get; set; }
    public string? CheckList { get; set; }
    public bool? RequestForAll { get; set; }
    public string? CustomerTypeList { get; set; }
    public bool? RequireScanning { get; set; }
    public string? RiskProfileList { get; set; }

    public virtual ICollection<IbsPeopleKyc> IbsPeopleKycs { get; set; }
}
