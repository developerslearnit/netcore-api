namespace IbsRestApi.Entities.iMoneytor;

public partial class IntegraToMoneytorTab
{
    public string? Refid { get; set; }
    public string? ActCode { get; set; }
    public string? Symbol { get; set; }
    public string? Cscsid { get; set; }
    public string? InvestorAccountNo { get; set; }
    public string? Narration { get; set; }
    public DateTime? ValueDate { get; set; }
    public decimal? UnitPrice { get; set; }
    public string? TransType { get; set; }
    public decimal? QtyUnit { get; set; }
    public decimal? Consideration { get; set; }
    public string? BrokerId { get; set; }
    public string? ContractNoteNo { get; set; }
    public decimal? StampDuty { get; set; }
    public decimal? Commission { get; set; }
    public decimal? Vat { get; set; }
    public decimal? Secfees { get; set; }
    public decimal? Nsefees { get; set; }
    public decimal? Cscsfees { get; set; }
    public decimal? OtherFees { get; set; }
    public decimal? TransactCost { get; set; }
    public decimal? TotalCostSalesProceed { get; set; }
    public decimal? CostOfShares { get; set; }
    public string Processed { get; set; } = null!;
    public int Id2moneytor { get; set; }
    public string? Comments { get; set; }
    
}
