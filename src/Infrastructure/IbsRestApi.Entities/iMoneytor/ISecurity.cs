namespace IbsRestApi.Entities.iMoneytor;

public partial class ISecurity
{
    public int IdSecurities { get; set; }
    public int? ShareId { get; set; }
    public int? IdDealMaster { get; set; }
    public int? IdLoanMaster { get; set; }
    public string? SecurityCode { get; set; }
    public string? SecurityName { get; set; }
    public string? SecType { get; set; }
    public string? SectorCode { get; set; }
    public decimal? NominalValue { get; set; }
    public string? IsInCode { get; set; }
    public string? ProductType { get; set; }
    public decimal? Rate { get; set; }
    public string? PaymentFrequency { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? MaturityDate { get; set; }
    public DateTime? NextPaymentDate { get; set; }
    public DateTime? LastPaymentDate { get; set; }
    public string? DayCountBasis { get; set; }
    public DateTime? RedemptionDate { get; set; }
    public decimal? IssuePrice { get; set; }
    public decimal? PriceFactor { get; set; }
    public string? Status { get; set; }
    
}
