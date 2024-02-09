using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IbsRestApi.Application.IMoneytor;

public class RedemptionViewModel
{
    public int ID_PortfolioContributorRedemption { get; set; }
    public int ID_PorfolioContributor { get; set; }
    public int ID_PortfolioContributorAccount { get; set; }
    public decimal NoOfUnits { get; set; }
    public decimal OfferPrice { get; set; }
    public bool Posted { get; set; }
    public int ID_RedemptionContributorAccount { get; set; }
    public decimal PenaltyAmount { get; set; }
    public decimal SalesValue { get; set; }
    public decimal NetSettlement { get; set; }
    public string CertificateNo { get; set; }
    public bool WaivePenalty { get; set; }
    public decimal CostOfUnits { get; set; }
    public int ID_Portfolio { get; set; }
    public decimal EmployerAmt { get; set; }
    public decimal EmployeeAmt { get; set; }
    public decimal AVCAmt { get; set; }
    public decimal AVCUnit { get; set; }
}
