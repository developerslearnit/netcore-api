namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsPfa
{
    public string IdPfa { get; set; } = null!;
    public string? PfaName { get; set; }
    public string? Address01 { get; set; }
    public string? Address02 { get; set; }
    public string? IdState { get; set; }
    public string? ContactPerson { get; set; }
    public string? GsmPhone1 { get; set; }
    public string? GsmPhone2 { get; set; }
    public string? Email { get; set; }
    public string? WebSite { get; set; }
}
