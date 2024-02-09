using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbsRestApi.Application.IMoneytor;
public class WalletTransactionModel
{
    public int ucid { get; set; }
    public string currencyId { get; set; }
    public decimal amount { get; set; }
    public string tranxRef { get; set; }
    public string paymentChannel { get; set; }
}
