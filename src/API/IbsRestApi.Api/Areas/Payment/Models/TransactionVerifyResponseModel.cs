namespace IbsRestApi.Api.Areas.Payment.Models;

public class TransactionVerifyResponseModel : TransactionInitResponseModel
{
    public string formated_amount {
        get {
            if (amount > 0)
            {
                return this.amount.ToString("#,##.00");
            }
            else
            {
                return "0.00";
            }
        }
    }
    public string formated_transdate {
        get {
            if (transactionDate.HasValue)
            {
                return transactionDate.Value.ToString("dd MMMM yyyy");
            }
            else { return DateTime.Now.ToString("dd MMMM yyyy"); }
        }
    }
    public bool status { get; set; }
}
