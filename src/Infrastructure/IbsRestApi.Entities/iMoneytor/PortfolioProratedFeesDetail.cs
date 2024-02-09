namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioProratedFeesDetail
{
    public int IdPortfolioProratedFeesDetails { get; set; }
    public int? IdPortfolioProratedFeesMaster { get; set; }
    public int? IdPortfolio { get; set; }
    public decimal? ManagementFees { get; set; }
    public decimal? PfcmgtFees { get; set; }
    public decimal? PcmmgtFees { get; set; }
    public decimal? NavBegin { get; set; }
    public decimal? NavEnd { get; set; }
    
}
