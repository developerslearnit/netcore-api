namespace IbsRestApi.Entities.Secure;

public partial class Group
{
    public Guid IdGroup { get; set; }
    public string GroupName { get; set; } = null!;
    public string IdApplication { get; set; } = null!;
}
