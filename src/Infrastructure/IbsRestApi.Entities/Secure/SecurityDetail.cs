namespace IbsRestApi.Entities.Secure;

public partial class SecurityDetail
{
    public int SecurityDetailId { get; set; }
    public string? ItemName { get; set; }
    public int? AccessLevel { get; set; }
    public string? Category { get; set; }
    public string? Description { get; set; }
    public string? IdApplication { get; set; }
    public string? ItemNameSearch { get; set; }
}
