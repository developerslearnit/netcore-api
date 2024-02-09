namespace IbsRestApi.Entities.iMoneytor;

public partial class OrderDetail
{
    public long OrderDetailId { get; set; }
    public string OrderReference { get; set; } = null!;
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
