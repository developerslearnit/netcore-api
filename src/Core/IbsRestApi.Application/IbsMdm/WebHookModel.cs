using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbsRestApi.Application.IbsMdm;
public class WebHookModel
{
    public string rawPayload { get; set; }
    public string referenceNo { get; set; }
    public decimal amount { get; set; }
    public string walletAccountNo { get; set; }
    public string originAccount { get; set; }
    public string originAccountName { get; set; }
    public string originBank { get; set; }
    public string originNarration { get; set; }
    public string transactionTimeStamp { get; set; }
    public DateTime loggedDate { get; set; }
    public string dateLogged { get { return this.loggedDate.ToString("dd/MMM/yyyy"); } }
}
