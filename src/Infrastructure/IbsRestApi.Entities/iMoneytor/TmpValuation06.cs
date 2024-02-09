namespace IbsRestApi.Entities.iMoneytor;

public partial class TmpValuation06
{
    public int IdTmpValuation05 { get; set; }
    public string? BrokerId { get; set; }
    public string? BrokerName { get; set; }
    public decimal? AmountPayable { get; set; }
    public decimal? AmountRecable { get; set; }
    public int? UniqueId { get; set; }
    public int? IdPortfolio { get; set; }
}
