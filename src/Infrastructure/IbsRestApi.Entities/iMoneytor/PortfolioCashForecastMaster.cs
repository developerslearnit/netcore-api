namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioCashForecastMaster
{
    public int IdPortfolioCashForecastMaster { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? ForecastDate { get; set; }
    public string? IdCurrency { get; set; }
    public decimal? MinCashBalance { get; set; }
    public decimal? OpeningBalance { get; set; }
    public decimal? MoneyMarket { get; set; }
    public decimal? Equity { get; set; }
    public decimal? Bond { get; set; }
    public decimal? RealEstate { get; set; }
    public decimal? OtherReceipts { get; set; }
    public string? ReceiptRemarks { get; set; }
    public decimal? FundsAvailable { get; set; }
    public decimal? PaymentsPlanned { get; set; }
    public string? PaymentRemarks { get; set; }
    public decimal? Available4Investment { get; set; }
    public string? ProposedInvestment { get; set; }
    public decimal? ClosingBalance { get; set; }
    public string? Status { get; set; }
    public string? PrepairedBy { get; set; }
    public string? Comments { get; set; }
    public string? ApprovedBy { get; set; }
    public decimal? X4openingBalance { get; set; }
    public decimal? X4receipts { get; set; }
    public decimal? X4payments { get; set; }
    public decimal? X4investment { get; set; }
    public decimal? X4closingBalance { get; set; }
    public decimal? AmountInvested { get; set; }
    
}
