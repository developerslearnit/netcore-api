using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbsRestApi.Entities.iMoneytor;
public class WalletTransaction
{
    public int WalletTransactionId { get; set; }
    public int Ucid { get; set; }
    public string IdCurrency { get; set; } = null!;
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }
    public string TransactionReference { get; set; } = null!;
    public string TransactionStatus { get; set; } = null;
}
