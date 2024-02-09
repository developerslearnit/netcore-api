namespace IbsRestApi.Entities.iMoneytor;

public partial class CustomerRating
{
    public int IdCustomerRating { get; set; }
    public int? IdCustomerRatingMaster { get; set; }
    public int? IdCustomer { get; set; }
    public int? IdRatingEngine { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public decimal? MaxExposureRate { get; set; }
    public string? Status { get; set; }
    
    public bool? IsNewOrModified { get; set; }
}
