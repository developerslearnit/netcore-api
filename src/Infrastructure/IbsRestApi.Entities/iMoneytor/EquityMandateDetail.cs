namespace IbsRestApi.Entities.iMoneytor;

public partial class EquityMandateDetail
{
    public int IdEquityMandateDetails { get; set; }
    public int? IdEquityMandateMaster { get; set; }
    public int? IdPortfolio { get; set; }
    public int? ShareId { get; set; }
    public decimal? QtyUnits { get; set; }
    public decimal? Amount { get; set; }
    public decimal? MaxPrice { get; set; }
    public bool? FreePrice { get; set; }
    public decimal? AmountIssued { get; set; }
    public decimal? UnitsIssued { get; set; }
    public decimal? AmountExecuted { get; set; }
    public decimal? UnitsExecuted { get; set; }
    
}
