namespace IbsRestApi.Entities.iMoneytor;

public partial class ActLog
{
    public string? Userid { get; set; }
    public string? Procname { get; set; }
    public string? Filename { get; set; }
    public string? Fieldname { get; set; }
    public string? Oldvalue { get; set; }
    public string? Newvalue { get; set; }
    public int? Date { get; set; }
    public int? Time { get; set; }
    public string? Recordid { get; set; }
    public string? Recordid2 { get; set; }
    public string? User1 { get; set; }
    public string? User2 { get; set; }
    public string? User3 { get; set; }
    public string? User4 { get; set; }
    public int? Delpointer { get; set; }
    public string? Type { get; set; }
    public string? Computername { get; set; }
    public string? Deletedfilename { get; set; }
    public string? Primafield { get; set; }
    public DateTime? ChangeTimeStamp { get; set; }
    public int IdActLog { get; set; }
    public int? Memopointer { get; set; }
}
