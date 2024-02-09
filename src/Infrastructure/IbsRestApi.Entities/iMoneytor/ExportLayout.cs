namespace IbsRestApi.Entities.iMoneytor;

public partial class ExportLayout
{
    public int IdExportLayout { get; set; }
    public string? SoftCode { get; set; }
    public string? FieldName { get; set; }
    public short? FieldPosition { get; set; }
    public short? FixedLenght { get; set; }
    public bool? IsDateField { get; set; }
    public string? DateFormat { get; set; }
    public string? DateToken { get; set; }
    public string? FixedData { get; set; }
    public bool? MakeAbsoluteValue { get; set; }
    public bool? Translate2DrCr { get; set; }
    public string? DrSign { get; set; }
    public string? CrSign { get; set; }
    public int? IdBankSoftware { get; set; }
    public string? Formular { get; set; }
    public bool? RemoveDateSeparator { get; set; }
    
    public string? TreatAmounAs { get; set; }
}
