namespace IbsRestApi.Entities.iMoneytor;

public partial class RoaImpar
{
    public int RoaImparedId { get; set; }
    public string? Investment { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal? Amount { get; set; }
    public string? Remarks { get; set; }
    public string? ExhibitId { get; set; }
    
}
