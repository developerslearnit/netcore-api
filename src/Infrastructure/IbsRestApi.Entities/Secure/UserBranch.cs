namespace IbsRestApi.Entities.Secure;

public partial class UserBranch
{
    public long IdUserBranch { get; set; }
    public Guid BranchId { get; set; }
    public Guid UserId { get; set; }
}
