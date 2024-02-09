namespace IbsRestApi.Entities.Secure;

public partial class UserGroup
{
    public Guid IdUserGroup { get; set; }
    public Guid IdUser { get; set; }
    public Guid IdGroup { get; set; }
    public string? IdApplication { get; set; }
}
