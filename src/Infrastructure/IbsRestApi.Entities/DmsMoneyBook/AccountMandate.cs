namespace IbsRestApi.Entities.DmsMoneyBook;

public partial class AccountMandate
{
    public int IdAccountMandate { get; set; }
    public int? Ucid { get; set; }
    public byte[]? Mandate { get; set; }
    public DateTime? CapturedDate { get; set; }
    public string? CapturedBy { get; set; }
}
