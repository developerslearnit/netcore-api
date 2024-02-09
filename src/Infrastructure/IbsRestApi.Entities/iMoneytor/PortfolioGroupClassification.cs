namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioGroupClassification
{
    public int IdPortfolioGroupClassification { get; set; }
    public string? FundClassCode { get; set; }
    public string? FundClass { get; set; }
    
    public int? MyId { get; set; }
    public string? IdCurrency { get; set; }
    public string? SensitivityLevel { get; set; }
    public DateTime? LastValuationDate { get; set; }
}
