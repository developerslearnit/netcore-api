namespace IbsRestApi.Entities.iMoneytor;

public partial class SignatoryOld
{
    public int IdSignatory { get; set; }
    public string? FullName { get; set; }
    public string? SignatoryLevel { get; set; }
    public decimal? Sign1Amount { get; set; }
    public decimal? Sign2Amount { get; set; }
    public byte[]? Signature { get; set; }
    public int? SecUserId { get; set; }
    public bool? SoleSignatory { get; set; }
}
