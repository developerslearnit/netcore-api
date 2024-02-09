namespace IbsRestApi.Entities.iMoneytor;

public partial class EqDivReceivableDetail
{
    public int IdEqDivReceivableDetails { get; set; }
    public int? IdEqDivReceivableMaster { get; set; }
    public int? ShareId { get; set; }
    public int? IdPortfolio { get; set; }
    public decimal? QtyUnit { get; set; }
    public decimal? Amount { get; set; }
    
}
