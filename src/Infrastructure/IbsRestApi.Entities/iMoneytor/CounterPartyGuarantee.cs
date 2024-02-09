namespace IbsRestApi.Entities.iMoneytor;

public partial class CounterPartyGuarantee
{
    public int IdCounterPartyGuarantee { get; set; }
    public int? IdCustomer { get; set; }
    public DateTime? ReceiveDate { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? CapturedBy { get; set; }
    public DateTime? CaptureDate { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    
}
