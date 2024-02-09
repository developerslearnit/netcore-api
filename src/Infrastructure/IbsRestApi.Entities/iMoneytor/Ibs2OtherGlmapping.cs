namespace IbsRestApi.Entities.iMoneytor;

public partial class Ibs2OtherGlmapping
{
    public int IdIbs2OtherGlmapping { get; set; }
    public string? IbsAccountNo { get; set; }
    public string? OtherAccountNo { get; set; }
    public string? OtherAccountName { get; set; }
    public string? OtherCostCenter { get; set; }
    public string? FundId { get; set; }
}
