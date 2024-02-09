namespace IbsRestApi.Entities.iMoneytor;

public partial class LnType
{
    public int LoanTypeId { get; set; }
    public string? Title { get; set; }
    public string? IdInvestmentType { get; set; }
    public string? PencomCode { get; set; }
    public string? IdCashForeCastClass { get; set; }
    public string? IdOutCashForeCastClass { get; set; }
    
    public int? IdSettlementModes { get; set; }
}
