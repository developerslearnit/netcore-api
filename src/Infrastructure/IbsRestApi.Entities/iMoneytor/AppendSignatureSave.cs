namespace IbsRestApi.Entities.iMoneytor;

public partial class AppendSignatureSave
{
    public int IdAppendSignature { get; set; }
    public DateTime? CreationDate { get; set; }
    public string? TransactionNarration { get; set; }
    public int? IdMoneyMarketExposureMaster { get; set; }
    public int? IdLoanMandateMaster { get; set; }
    public int? IdEquityMandateToBrokers { get; set; }
    public decimal? Amount { get; set; }
    public int? Sign1Id { get; set; }
    public DateTime? Sign1Date { get; set; }
    public int? Sign2Id { get; set; }
    public DateTime? Sign2Date { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public int? IdPortfolio { get; set; }
    public int? IdDealTerminate { get; set; }
    public int? IdMatureDealMaster { get; set; }
}
