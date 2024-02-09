namespace IbsRestApi.Entities.iMoneytor;

public partial class RealEstateGlextract
{
    public int IdRealEstateGlextract { get; set; }
    public string? RealEstateName { get; set; }
    public string? Real1ActNo { get; set; }
    public string? Real2ActNo { get; set; }
    public string? RealEstateType { get; set; }
    public int? IdPortfolio { get; set; }
    public string? IdInvestmentType { get; set; }
    public string? IdCurrency { get; set; }
    
    public string? Real1ActNoCcenter { get; set; }
    public string? Real2ActNoCcenter { get; set; }
}
