namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsBirthdayMessage
{
    public int IdBirthdayMessages { get; set; }
    public int? Ucid { get; set; }
    public DateTime? CreationDate { get; set; }
    public DateTime? BirthDate { get; set; }
    public int? IdMessageServer { get; set; }
    public string? MessageType { get; set; }
}
