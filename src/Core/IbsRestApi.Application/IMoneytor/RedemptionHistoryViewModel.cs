namespace IbsRestApi.Application.IMoneytor;

public class RedemptionHistoryViewModel
{
    public int transactionId { get; set; }
    public int ucId { get; set; }
    public int portfolioId { get; set; }
    public int portcontributorId { get; set; }
    public int portfolioContributorAccountId { get; set; }
    public decimal noOfUnits { get; set; }
    public decimal offerPrice { get; set; }
    public decimal penaltyAmount { get; set; }
    public decimal salesValue { get; set; }
    public decimal netSettlement { get; set; }
    public string description { get; set; }
    public DateTime transDate { get; set; }
    public string portfolioName { get; set; }
    public string status { get; set; }

    public string strSalesValue { get { return this.salesValue.ToString("#,00.00"); } }
    public string transactionDate { get { return this.transDate.ToString("dd/MM/yyyy"); } }
    public string strNoOfUnits { get { return string.Format("{0:0000.0000}", this.noOfUnits); } }
    public string strOfferPrice { get { return string.Format("{0:0.0000}", this.offerPrice); } }
    public string strPenaltyAmount { get { return this.penaltyAmount.ToString("#,00.00"); } }
    public string strNetSettlement { get { return this.netSettlement.ToString("#,00.00"); } }
}
