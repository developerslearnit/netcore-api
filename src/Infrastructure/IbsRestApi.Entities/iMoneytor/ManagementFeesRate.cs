namespace IbsRestApi.Entities.iMoneytor;

public partial class ManagementFeesRate
{
    public int IdManagementFeesRate { get; set; }
    public decimal? BeginAmount { get; set; }
    public decimal? EndAmount { get; set; }
    public decimal? PfamgtFees { get; set; }
    public decimal? PfcmgtFees { get; set; }
    public decimal? PcmmgtFees { get; set; }
    
}
