namespace IbsRestApi.Entities.iMoneytor;

public partial class EqReqDetail
{
    public int IdEqReqDetails { get; set; }
    public int? IdEqReqMaster { get; set; }
    public int? IdPortfolio { get; set; }
    public decimal? QtyUnit { get; set; }
    public decimal? AllocatedCost { get; set; }
    public decimal? ComChgAmount { get; set; }
    
}
