namespace IbsRestApi.Entities.iMoneytor;

public partial class EqtSplit
{
    public int IdEqtSplit { get; set; }
    public int? UniqueId { get; set; }
    public decimal? UnitCost { get; set; }
    public int? QtyUnit { get; set; }
    public int? Cscsqty { get; set; }
    public int? CertificateQty { get; set; }
    public decimal? Consideration { get; set; }
    public string? ContractNoteNo { get; set; }
    public decimal? StampDuty { get; set; }
    public decimal? Commission { get; set; }
    public decimal? Vat { get; set; }
    public decimal? SecFees { get; set; }
    public decimal? NseCscsfees { get; set; }
    public decimal? OtherFees { get; set; }
    public decimal? Premuim { get; set; }
    public decimal? Discount { get; set; }
    public decimal? TransactionCost { get; set; }
    public decimal? TotalCost { get; set; }
    public int? NewUniqueId { get; set; }
    
}
