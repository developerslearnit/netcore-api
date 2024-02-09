namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioProratedFeesMaster
{
    public int IdPortfolioProratedFeesMaster { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public string? Narration { get; set; }
    public string? MgtFeesPer { get; set; }
    public string? PfcfeesPer { get; set; }
    public string? PcmfeesPer { get; set; }
    public bool? ReducingBalanceMetod { get; set; }
    public string? PfaNavType { get; set; }
    public string? PfcNavType { get; set; }
    public string? PcmNavType { get; set; }
    
}
