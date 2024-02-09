namespace IbsRestApi.Entities.IbsMdm;

public partial class ReadNotification
{
    public long Id { get; set; }
    public Guid UserId { get; set; }
    public long IdNotification { get; set; }
    public DateTime DateRead { get; set; }
}
