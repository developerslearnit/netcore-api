namespace IbsRestApi.Entities.iMoneytor;

public partial class RoaCaBnk
{
    public int CaBnkId { get; set; }
    public int? CurrCallId { get; set; }
    public DateTime? ValueDate { get; set; }
    public decimal? Income { get; set; }
    public decimal? BankCharges { get; set; }
    
}
