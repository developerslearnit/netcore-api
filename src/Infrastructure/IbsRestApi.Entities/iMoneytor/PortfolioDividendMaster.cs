﻿namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioDividendMaster
{
    public PortfolioDividendMaster()
    {
        PortfolioDividendAllocations = new HashSet<PortfolioDividendAllocation>();
    }

    public int IdPortfolioDividendMaster { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? ValueDate { get; set; }
    public string? Narration { get; set; }
    public decimal? Amount2Share { get; set; }
    public decimal? Units2Share { get; set; }
    public DateTime? ClosureDate { get; set; }
    public string? CaptureBy { get; set; }
    public string? ApprovedBy { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public string? VoucherNo { get; set; }
    public DateTime? GlPostDate { get; set; }
    public decimal? GrossFundUnits { get; set; }
    public decimal? DividendRate { get; set; }
    public decimal? BonusRate { get; set; }
    public decimal? BonusFor { get; set; }
    public string? TransactionType { get; set; }
    public DateTime? BeginDate { get; set; }
    public decimal? WithTaxAmount { get; set; }
    
    public decimal? PortionToShare { get; set; }

    public virtual ICollection<PortfolioDividendAllocation> PortfolioDividendAllocations { get; set; }
}
