﻿namespace IbsRestApi.Entities.iMoneytor;

public partial class Vw19ValuationSummary
{
    public int? IdPortfolio { get; set; }
    public string? IdInvestmentType { get; set; }
    public DateTime? ValuationDate { get; set; }
    public decimal? CostOfAsset { get; set; }
    public decimal? AssetValue { get; set; }
    public int? IdValuationSumary { get; set; }
}
