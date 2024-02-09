namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsPeopleEmployer
{
    public int IdEmployer { get; set; }
    public int? Ucid { get; set; }
    public string? EmployerCode { get; set; }
    public string? EmploymentType { get; set; }
    public int? IdOccupation { get; set; }
    public string? Address01 { get; set; }
    public string? Address02 { get; set; }
    public string? City { get; set; }
    public string? IdState { get; set; }
    public string? IdCountry { get; set; }
    public string? Website { get; set; }
    public DateTime? DateEmployed { get; set; }

    public virtual IbsEmployer? EmployerCodeNavigation { get; set; }
}
