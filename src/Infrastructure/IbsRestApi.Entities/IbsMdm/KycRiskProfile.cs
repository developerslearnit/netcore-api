namespace IbsRestApi.Entities.IbsMdm;

public partial class KycRiskProfile
{
    public string IdKycRiskProfile { get; set; } = null!;
    public string? RiskProfile { get; set; }
    public decimal? MinDeposit { get; set; }
    public decimal? MaxDeposit { get; set; }
    public decimal? MaxBalance { get; set; }
    public decimal? MaxRedemption { get; set; }
}
