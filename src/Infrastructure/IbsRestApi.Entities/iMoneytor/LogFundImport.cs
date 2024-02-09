namespace IbsRestApi.Entities.iMoneytor;

public partial class LogFundImport
{
    public int IdLogFundImport { get; set; }
    public int? IdLogMaster { get; set; }
    public DateTime? CreationDate { get; set; }
    public int? IdPortfolio { get; set; }
    public string? DataFileName { get; set; }
    public string? Comments { get; set; }
    
}
