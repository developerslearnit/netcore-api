namespace IbsRestApi.Entities.iMoneytor;

public partial class EqCert
{
    public int IdEqCert { get; set; }
    public int UniqueId { get; set; }
    public int ShareId { get; set; }
    public string? ContractNote { get; set; }
    public string CertificateId { get; set; } = null!;
    public decimal? QtyUnits { get; set; }
    public decimal? ExtraQty { get; set; }
    public string? BrokerId { get; set; }
    public int? ImmobilizeId { get; set; }
    public int? ConsolidateId { get; set; }
    public byte? Immobilized { get; set; }
    public int? DisposalId { get; set; }
    public DateTime? TransactionDate { get; set; }
    public int? IdDealMaster { get; set; }
    public int? LoanId { get; set; }
    
}
