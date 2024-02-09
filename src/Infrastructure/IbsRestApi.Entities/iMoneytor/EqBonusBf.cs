namespace IbsRestApi.Entities.iMoneytor;

public partial class EqBonusBf
{
    public int IdEqBonusBf { get; set; }
    public int? ShareId { get; set; }
    public int? IdPortfolio { get; set; }
    public string? Narration { get; set; }
    public DateTime? OpenDate { get; set; }
    public int? BonusQty { get; set; }
    
}
