namespace IbsRestApi.Entities.iMoneytor;

public partial class CurrencyAccountMapping
{
    public int IdCurrencyAccountMapping { get; set; }
    public string? IdBankAccount { get; set; }
    public string? IdCurrency { get; set; }
    public string? IdCashMgtAccountLogement { get; set; }
    public string? IdCashMgtAccountWithdrawal { get; set; }
}
