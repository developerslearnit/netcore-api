namespace IbsRestApi.Entities.iMoneytor;

public partial class Deal2Gl
{
    public int IdDeal2Gl { get; set; }
    public string? IdDealType { get; set; }
    public int? PortfolioId { get; set; }
    public string? Title { get; set; }
    public string? DealMainActNo { get; set; }
    public string? DealIncomeActNo { get; set; }
    public string? DealAccrualActNo { get; set; }
    public string? DealExpActNo { get; set; }
    public int? IdPortfolioGroup { get; set; }
    public string? ProfitLossOnDisposal { get; set; }
    
    public string? UnRealisedGain { get; set; }
    public string? ChangeInBondValueGlActNo { get; set; }
    public string? UnRealisedLoss { get; set; }
    public string? DealMainActNoCcenter { get; set; }
    public string? DealIncomeActNoCcenter { get; set; }
    public string? DealAccrualActNoCcenter { get; set; }
    public string? DealExpActNoCcenter { get; set; }
    public int? IdPortfolioGroupCcenter { get; set; }
    public string? ProfitLossOnDisposalCcenter { get; set; }
    public string? UnRealisedGainCcenter { get; set; }
    public string? ChangeInBondValueGlActNoCcenter { get; set; }
    public string? UnRealisedLossCcenter { get; set; }
}
