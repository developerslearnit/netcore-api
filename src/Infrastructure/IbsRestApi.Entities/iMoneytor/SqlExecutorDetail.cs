namespace IbsRestApi.Entities.iMoneytor;

public partial class SqlExecutorDetail
{
    public int IdSqlExecutorDetails { get; set; }
    public int? IdSqlExecutorMaster { get; set; }
    public string? SqlScript { get; set; }
    public bool? Executed { get; set; }
    public string? SqlMessage { get; set; }
}
