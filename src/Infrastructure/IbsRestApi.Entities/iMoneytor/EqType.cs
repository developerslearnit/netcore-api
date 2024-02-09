namespace IbsRestApi.Entities.iMoneytor;

public partial class EqType
{
    public string TypeId { get; set; } = null!;
    public string? Title { get; set; }
    public string? IdInvestmentType { get; set; }
    public string? PencomCode { get; set; }
    public bool? CalculateCharges { get; set; }
    public string? IdCashForeCastClass { get; set; }
    public string? IdOutCashForeCastClass { get; set; }
    
    public string? ShareClass { get; set; }
}
