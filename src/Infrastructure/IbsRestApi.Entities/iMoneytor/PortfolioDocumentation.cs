namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioDocumentation
{
    public int IdPortfolioDocumentation { get; set; }
    public int? IdPortfolio { get; set; }
    public int? IdDocumentMaster { get; set; }
    public bool? Submited { get; set; }
    
}
