namespace IbsRestApi.Entities.iMoneytor;

public partial class RoaComp
{
    public int RoaCompId { get; set; }
    public string? IntestmentType { get; set; }
    public int? PortfolioId { get; set; }
    public DateTime? Prd01Date { get; set; }
    public decimal? Prd01Income { get; set; }
    public decimal? Prd01Amount { get; set; }
    public decimal? Prd01Yeild { get; set; }
    public DateTime? Prd02Date { get; set; }
    public decimal? Prd02Income { get; set; }
    public decimal? Prd02Amount { get; set; }
    public decimal? Prd02Yeild { get; set; }
    public decimal? Variance { get; set; }
    public string? ExhibitId { get; set; }
    
}
