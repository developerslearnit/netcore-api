namespace IbsRestApi.Entities.iMoneytor;

public partial class IbsSourceOfFund
{
    public string IdSourceOfFund { get; set; } = null!;
    public string? SourceOfFund { get; set; }
    public bool? RequireEmployer { get; set; }
}
