namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsIncomeRange
{
    public int IdIncomeRange { get; set; }
    public decimal? BeginAmount { get; set; }
    public decimal? EndAmount { get; set; }
    public string? Description { get; set; }
}
