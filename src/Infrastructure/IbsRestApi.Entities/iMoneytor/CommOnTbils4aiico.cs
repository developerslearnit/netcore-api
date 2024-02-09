namespace IbsRestApi.Entities.iMoneytor;

public partial class CommOnTbils4aiico
{
    public int IdDealMaster { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public DateTime? MaturityDate { get; set; }
    public decimal? FaceAmount { get; set; }
    public string? IdDealType { get; set; }
    public string? Description { get; set; }
    public string? DealType { get; set; }
    public int? IdPortfolio { get; set; }
    public string? Portfolio { get; set; }
    public decimal? CommisionAmount { get; set; }
    public decimal? ComisionRate { get; set; }
}
