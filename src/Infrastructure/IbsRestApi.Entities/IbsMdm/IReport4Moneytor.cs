namespace IbsRestApi.Entities.IbsMdm;

public partial class IReport4Moneytor
{
    public IReport4Moneytor()
    {
        IReport4MoneytorParameters = new HashSet<IReport4MoneytorParameter>();
    }

    public int Reportid { get; set; }
    public string? Narration { get; set; }
    public string? Reportfilename { get; set; }
    public string? Runbefore { get; set; }
    public byte? Show4All { get; set; }
    public byte? Show4Portfolio { get; set; }
    public byte? Show4Contributor { get; set; }
    public int? IdReportgroup { get; set; }
    public string? Sensitivitylevel { get; set; }
    public string? IdApplication { get; set; }
    public bool? AllowMassReport { get; set; }
    public string? ReportParameter { get; set; }
    public string? IbsParameter { get; set; }
    public byte? Show4Portfoliogroup { get; set; }

    public virtual ICollection<IReport4MoneytorParameter> IReport4MoneytorParameters { get; set; }
}
