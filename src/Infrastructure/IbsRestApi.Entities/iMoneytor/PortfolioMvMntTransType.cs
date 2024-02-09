namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioMvMntTransType
{
    public string TransactionType { get; set; } = null!;
    public string? Description { get; set; }
    public string? GlActNo { get; set; }
    public string? BankGlActNo { get; set; }
    public string? InflowActNo { get; set; }
    public string? SfkaccountCode { get; set; }
    public int IdPortfolioMovementType { get; set; }
}
