namespace IbsRestApi.Entities.IbsMdm;

public partial class CorporateActionDetail
{
    public int IdCorporateActionDetail { get; set; }
    public int? IdCorporateActionMaster { get; set; }
    public decimal? DividendRate { get; set; }
    public DateTime? PaymentDate { get; set; }
    public string? DividendType { get; set; }
    public DateTime? ClosureDate { get; set; }
    public int? DeclaredId { get; set; }
    public int? ShareId { get; set; }
    public bool? DoNotPost { get; set; }

    public virtual CorporateActionMaster? IdCorporateActionMasterNavigation { get; set; }
}
