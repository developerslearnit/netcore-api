namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioDirectGldetail
{
    public int IdPortfolioDirectGldetails { get; set; }
    public int? IdPortfolioDirectGlmaster { get; set; }
    public string? IdBranch { get; set; }
    public string? IdProductLine { get; set; }
    public string? IdLocation { get; set; }
    public string? GlactNo { get; set; }
    public string? Description { get; set; }
    public short? DrCr { get; set; }
    public decimal? LocalAmount { get; set; }
    public decimal? ExRate { get; set; }
    public decimal? ForexAmount { get; set; }
    public bool? AffectCash { get; set; }
    public bool? AffectPl { get; set; }
    public string? IdCurrency { get; set; }
    public string? Acode01 { get; set; }
    public string? Acode02 { get; set; }
    public string? Acode03 { get; set; }
    public string? Acode04 { get; set; }
    public string? Acode05 { get; set; }
    public DateTime? ValueDate { get; set; }
    public string? IdCashForeCastClass { get; set; }
    
    public decimal? UnitPrice { get; set; }
    public decimal? NoOfUnits { get; set; }
    public bool? Unitize { get; set; }
    public string? Acode06 { get; set; }
    public string? Acode07 { get; set; }
    public string? Acode08 { get; set; }
    public string? Acode09 { get; set; }
    public string? Acode10 { get; set; }
    public int? Usid { get; set; }
    public int? Upid { get; set; }
    public int? Ueid { get; set; }
    public int? Ucid { get; set; }
}
