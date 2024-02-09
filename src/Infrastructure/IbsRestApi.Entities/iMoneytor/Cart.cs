namespace IbsRestApi.Entities.iMoneytor;

public partial class Cart
{
    public long RecordId { get; set; }
    public string CartId { get; set; } = null!;
    public int ProductId { get; set; }
    public int Count { get; set; }
    public DateTime? DateCreated { get; set; }
    public decimal Amount { get; set; }
}
