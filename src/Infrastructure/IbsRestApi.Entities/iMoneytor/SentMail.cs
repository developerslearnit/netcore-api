namespace IbsRestApi.Entities.iMoneytor;

public partial class SentMail
{
    public int SentId { get; set; }
    public string? SentTo { get; set; }
    public string? AttachedFile { get; set; }
    public DateTime? SentDate { get; set; }
    public string? MessageText { get; set; }
    
}
