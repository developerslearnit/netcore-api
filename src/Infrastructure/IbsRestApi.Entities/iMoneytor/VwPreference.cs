namespace IbsRestApi.Entities.iMoneytor;

public partial class VwPreference
{
    public int IdPreferences { get; set; }
    public string? IdApplication { get; set; }
    public bool? Link2MoneyBook { get; set; }
    public bool? Post2Gl { get; set; }
    public string? MoneyBookDatabaseName { get; set; }
}
