namespace IbsRestApi.Entities.iMoneytor;

public partial class SqlExecutorMaster
{
    public int IdSqlExecutorMaster { get; set; }
    public DateTime? LoadDate { get; set; }
    public string? VersionNotes { get; set; }
    public DateTime? ExecutionDate { get; set; }
    public string? ExecutedBy { get; set; }
    public bool? Executed { get; set; }
}
