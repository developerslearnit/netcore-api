namespace IbsRestApi.Entities.iMoneytor;

public partial class CustomerRatingMaster
{
    public int IdCustomerRatingMaster { get; set; }
    public DateTime? RequestDate { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public string? Narration { get; set; }
    public string? CapturedBy { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovedDate { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    
    public int? IdPortfolio { get; set; }
}
