namespace IbsRestApi.Entities.Secure;

public partial class GroupMenu
{
    public int IdGroupMenu { get; set; }
    public Guid? IdGroup { get; set; }
    public Guid? IdMenu { get; set; }
    public string? IdApplication { get; set; }
}
