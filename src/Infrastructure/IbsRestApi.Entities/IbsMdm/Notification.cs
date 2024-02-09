namespace IbsRestApi.Entities.IbsMdm;

public partial class Notification
{
    public long IdNotification { get; set; }
    public string Message { get; set; } = null!;
    public bool IsRead { get; set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateRead { get; set; }
    public string IdApplication { get; set; } = null!;
    public bool? MailSent { get; set; }
    public long? LinkId { get; set; }
    public string? IdBranch { get; set; }
    public string? BranchName { get; set; }
    public long? IdNotificationModule { get; set; }
    public DateTime? LastDateSent { get; set; }
}
