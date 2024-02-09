namespace IbsRestApi.Entities.iMoneytor;

public partial class LnTreatmentType
{
    public string IdTreatmentType { get; set; } = null!;
    public string? Treatment { get; set; }
    public string? ValuationMethod { get; set; }
    public bool? HoldToMaturity { get; set; }
    public int? SellWithinDays { get; set; }
    public string? AmortisePremiumOrDiscount { get; set; }
    public bool? CalculateYieldDaily { get; set; }
}
