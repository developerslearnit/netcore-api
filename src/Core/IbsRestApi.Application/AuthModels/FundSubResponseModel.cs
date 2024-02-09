using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbsRestApi.Application.AuthModels;
public class FundSubResponseModel
{
    public DateTime TransactionDate { get; set; }

    public string TransDate { get { return this.TransactionDate.ToString("dd MMMM yyyy"); } }

    public string ProductName { get; set; }
    public string Amount { get; set; }
}
