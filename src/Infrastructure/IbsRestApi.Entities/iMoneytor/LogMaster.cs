namespace IbsRestApi.Entities.iMoneytor;

public partial class LogMaster
{
    public int IdLogMaster { get; set; }
    public DateTime? LogDate { get; set; }
    public string? CapturedBy { get; set; }
    public string? ProcessName { get; set; }
    
}
