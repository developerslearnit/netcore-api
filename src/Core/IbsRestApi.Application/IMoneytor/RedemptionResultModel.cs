using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbsRestApi.Application.IMoneytor;

public class RedemptionResultModel
{
    public List<RedemptionViewModel> certList { get; set; }
    public string netSettlement { get; set; }
    public string noOfUnit { get; set; }
}
