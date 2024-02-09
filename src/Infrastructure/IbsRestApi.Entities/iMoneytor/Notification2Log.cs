namespace IbsRestApi.Entities.iMoneytor;

public partial class Notification2Log
{
    public int IdNotification2Log { get; set; }
    public string? LogType { get; set; }
    public int? IdPortfolio { get; set; }
    public int? IdPortfolioContributor { get; set; }
    public int? IdPortfolioContributorAccount { get; set; }
    public DateTime? RequestDate { get; set; }
    public DateTime? SentDate { get; set; }
    public string? Subject { get; set; }
    public string? EMailMessage { get; set; }
    public string? EMailStatus { get; set; }
    public string? Smsmessage { get; set; }
    public string? SmsStatus { get; set; }
    public DateTime? ResponseDate { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    
    public bool? EMailIsHtml { get; set; }
}
