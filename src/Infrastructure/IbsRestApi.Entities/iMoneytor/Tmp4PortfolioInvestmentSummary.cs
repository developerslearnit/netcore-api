﻿namespace IbsRestApi.Entities.iMoneytor;

public partial class Tmp4PortfolioInvestmentSummary
{
    public int IdPortfolioInvestmentSummary { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? Valuedate { get; set; }
    public string? IdInvestmentType { get; set; }
    public decimal? Assetvalue { get; set; }
    public decimal? Costofasset { get; set; }
    public decimal? Pcentgainloss { get; set; }
    public decimal? Pcentoftotal { get; set; }
}
