namespace IbsRestApi.Entities.DmsMoneyBook;

public partial class CustomerPhoto
{
    public int IdCustomerPhoto { get; set; }
    public int? Ucid { get; set; }
    public byte[]? PhotoImage { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? IdJointMember { get; set; }
    public string? ImageExt { get; set; }
}
