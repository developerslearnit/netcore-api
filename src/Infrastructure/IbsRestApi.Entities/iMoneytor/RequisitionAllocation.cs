namespace IbsRestApi.Entities.iMoneytor;

public partial class RequisitionAllocation
{
    public int IdRequisitionAllocation { get; set; }
    public int? IdRequisition { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? ValueDate { get; set; }
    public decimal? Amount { get; set; }
    public decimal? Commision { get; set; }
    
}
