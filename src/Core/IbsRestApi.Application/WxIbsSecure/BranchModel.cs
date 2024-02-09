using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbsRestApi.Application.WxIbsSecure;
public class BranchModel
{
    public Guid BranchId { get; set; }
    public string BranchName { get; set; } = string.Empty;
    public string ServerName { get; set; } = string.Empty;
    public string DbUsername { get; set; } = string.Empty;
    public string DbPassword { get; set; } = string.Empty;
    public string IMoneytorDbName { get; set; } = string.Empty;
    public string MoneyBookDbName { get; set; } = string.Empty;
}
