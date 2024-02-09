namespace IbsRestApi.Entities.iMoneytor;

public partial class BankingSoftware
{
    public int IdBankSoftware { get; set; }
    public string? SoftCode { get; set; }
    public string? SoftwareName { get; set; }
    public string? AsciiFormat { get; set; }
    public string? SeparateXter { get; set; }
    public int? RecordLenght { get; set; }
    public string? SaveAsFormat { get; set; }
    public string? ExportHeader { get; set; }
    public bool? TrimActNoTrailingZeros { get; set; }
    
}
