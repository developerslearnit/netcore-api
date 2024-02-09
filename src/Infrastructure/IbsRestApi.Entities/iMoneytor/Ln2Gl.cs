namespace IbsRestApi.Entities.iMoneytor;

public partial class Ln2Gl
{
    public int LoanTypeId { get; set; }
    public int PortfolioId { get; set; }
    public string? Title { get; set; }
    public string? GlassetActNo { get; set; }
    public string? GlincomeActNo { get; set; }
    public string? GlaccrualActNo { get; set; }
    public string? GlexpenseActNo { get; set; }
    public int? IdPortfolioGroup { get; set; }
    public string? GlgainLossActNo { get; set; }
    public int IdLn2Gl { get; set; }
    public string? GlpremAssetActNo { get; set; }
    public string? GldiscAssetActNo { get; set; }
    public string? GlpremLossActNo { get; set; }
    public string? GldiscGainActNo { get; set; }
    public string? GllossActNo { get; set; }
    public string? UnRealisedGain { get; set; }
    public string? ChangeInBondValueGlActNo { get; set; }
    public string? UnRealisedLoss { get; set; }
    public string? GlassetActNoCcenter { get; set; }
    public string? GlincomeActNoCcenter { get; set; }
    public string? GlaccrualActNoCcenter { get; set; }
    public string? GlexpenseActNoCcenter { get; set; }
    public string? GlgainLossActNoCcenter { get; set; }
    public string? GlpremAssetActNoCcenter { get; set; }
    public string? GldiscAssetActNoCcenter { get; set; }
    public string? GlpremLossActNoCcenter { get; set; }
    public string? GldiscGainActNoCcenter { get; set; }
    public string? GllossActNoCcenter { get; set; }
    public string? UnRealisedGainCcenter { get; set; }
    public string? ChangeInBondValueGlActNoCcenter { get; set; }
    public string? UnRealisedLossCcenter { get; set; }
}
