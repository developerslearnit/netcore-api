namespace IbsRestApi.Entities.iMoneytor;

public partial class IbsMainCategory
{
    public string IdMainCategory { get; set; } = null!;
    public string MainCategory { get; set; } = null!;
    public string? IdCategoryClass { get; set; }
    public bool? PrintSchedule { get; set; }
}
