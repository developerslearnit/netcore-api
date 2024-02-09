namespace IbsRestApi.Application.IMoneytor;

public class ExistingClientOrderModel
{
    public int ucid { get; set; }
    public string currencyId { get; set; }
    public int portfolioId { get; set; }
    public decimal amount { get; set; }
    public string tranxRef { get; set; }
    public string paymentChannel { get; set; }
    public int tenor { get; set; } = 0;
}
