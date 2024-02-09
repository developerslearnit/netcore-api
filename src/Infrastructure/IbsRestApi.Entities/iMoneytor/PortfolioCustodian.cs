namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioCustodian
{
    public int IdPortfolioCustodian { get; set; }
    public string? PfcCode { get; set; }
    public string? PfcName { get; set; }
    public string? PfcAddress01 { get; set; }
    public string? PfcAddress02 { get; set; }
    public string? IdPfcState { get; set; }
    public string? PfcContact { get; set; }
    public string? PfcEmail { get; set; }
    public string? PfcTelephones { get; set; }
    public string? PfcGsmNo { get; set; }
    public string? PfcBankCode { get; set; }
    public string? Pfc2PfaFolder { get; set; }
    public string? Pfa2PfcFolder { get; set; }
    public string? Status { get; set; }
    public string? CapturedBy { get; set; }
    public DateTime? CapturedDate { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovedDate { get; set; }
    public string? Comments { get; set; }
}
