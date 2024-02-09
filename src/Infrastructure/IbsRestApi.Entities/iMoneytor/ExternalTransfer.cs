namespace IbsRestApi.Entities.iMoneytor;

public partial class ExternalTransfer
{
    public int IdExternalTransfer { get; set; }
    public int? IdRequisitionMaster { get; set; }
    public int? IdDealMaster { get; set; }
    public decimal? Amount { get; set; }
    public DateTime? TransferDate { get; set; }
    public string? Narration { get; set; }
    public string? TransType { get; set; }
    public string? VoucherNo { get; set; }
    public string? IdBranch { get; set; }
    public DateTime? GlpostDate { get; set; }
    public string? GlPostPeriod { get; set; }
    public decimal? Principal { get; set; }
    public decimal? Interest { get; set; }
    public string? InvestmentModule { get; set; }
    public decimal? InterestAdjustment { get; set; }
    public int? IdTermination { get; set; }
    
    public long? Utid { get; set; }
}
