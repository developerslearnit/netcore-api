namespace IbsRestApi.Entities.iMoneytor;

public partial class Nltranm
{
    public int UniqueNo { get; set; }
    public string Nlyear { get; set; } = null!;
    public string PostingCode { get; set; } = null!;
    public string TransPeriod { get; set; } = null!;
    public string Element1 { get; set; } = null!;
    public string Element2 { get; set; } = null!;
    public string Element3 { get; set; } = null!;
    public string Element4 { get; set; } = null!;
    public string Element5 { get; set; } = null!;
    public string AccountCode { get; set; } = null!;
    public string JournalNumber { get; set; } = null!;
    public DateTime? JournalDate { get; set; }
    public string JournalDesc { get; set; } = null!;
    public DateTime? PostDate { get; set; }
    public string NlContra { get; set; } = null!;
    public string Origin { get; set; } = null!;
    public string VatCode { get; set; } = null!;
    public double JournalAmount { get; set; }
    public string FromPeriod { get; set; } = null!;
    public string CurrencyCode { get; set; } = null!;
    public double CurrencyAmount { get; set; }
    public string HistoryRef { get; set; } = null!;
    public string Spare { get; set; } = null!;
    public DateTime? TransactionDate { get; set; }
    public string CurrencyType { get; set; } = null!;
    public string RevalueStatus { get; set; } = null!;
    public string AnalysisCode1 { get; set; } = null!;
    public string AnalysisCode2 { get; set; } = null!;
    public string AnalysisCode3 { get; set; } = null!;
    public string Source1 { get; set; } = null!;
    public string Source2 { get; set; } = null!;
    public string Multidiv { get; set; } = null!;
    public double ExchangeRate { get; set; }
    public double ReportAmount { get; set; }
    public double PreBaseAmt { get; set; }
    public double PreReptAmt { get; set; }
    public string TransactionGroup { get; set; } = null!;
    public string Seq { get; set; } = null!;
    public string BatchReference { get; set; } = null!;
    public int? Period { get; set; }
}
