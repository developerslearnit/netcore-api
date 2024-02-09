using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbsRestApi.Application.IMoneytor;

public class TransactionViewModel
{
    public string cssClass {
        get {
            return amount > 0 ? "text-success" : "text-danger";
        }
    }
    public int transactionId { get; set; }
    public int portfolioId { get; set; }
    public DateTime transDate { get; set; }
    public DateTime valueDate { get; set; }
    public string strtransDate { get; set; }
    public string strvalueDate { get; set; }
    public string portfolioName { get; set; }
    public decimal amount { get; set; }
    public string transactionType { get; set; }
    public string transactionDescription { get; set; }
    public int id_portcontributor { get; set; }
    public string paymentType { get; set; }
    public string status { get; set; }
    public string tranType { get; set; }
    public string stramount { get; set; }
}
