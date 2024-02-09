namespace IbsRestApi.Entities.iMoneytor;

public partial class Eq2Gl
{
    public int IdEq2Gl { get; set; }
    public string TypeId { get; set; } = null!;
    public string? Title { get; set; }
    public string? ShareGlactNo { get; set; }
    public string? DividendGlactNo { get; set; }
    public string? Dep4ShareGlActNo { get; set; }
    public string? DisposalProfLoss { get; set; }
    public string? UnRealisedGain { get; set; }
    public string? UnRealisedLoss { get; set; }
    public int? IdPortfolioGroup { get; set; }
    public string? ReceivableOnSales { get; set; }
    public string? PayableOnPurchase { get; set; }
    public string? ChangeInShareValueGlActNo { get; set; }
    public string? DivReceivableGlActNo { get; set; }
    public string? RealisedLossGlActNo { get; set; }
    
    public string? TransCostGlActNo { get; set; }
    public string? ShareGlactNoCcenter { get; set; }
    public string? DividendGlactNoCcenter { get; set; }
    public string? Dep4ShareGlActNoCcenter { get; set; }
    public string? DisposalProfLossCcenter { get; set; }
    public string? UnRealisedGainCcenter { get; set; }
    public string? UnRealisedLossCcenter { get; set; }
    public string? ReceivableOnSalesCcenter { get; set; }
    public string? PayableOnPurchaseCcenter { get; set; }
    public string? ChangeInShareValueGlActNoCcenter { get; set; }
    public string? RealisedLossGlActNoCcenter { get; set; }
    public string? DivReceivableGlActNoCcenter { get; set; }
    public string? TransCostGlActNoCcenter { get; set; }
}
