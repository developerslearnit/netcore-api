namespace IbsRestApi.Entities.iMoneytor;

public partial class DataBridge
{
    public int IdDatabridge { get; set; }
    public string Databasename { get; set; } = null!;
    public string Tablename { get; set; } = null!;
    public string OldId { get; set; } = null!;
    public string CommonId { get; set; } = null!;
    public string NewId { get; set; } = null!;
}
