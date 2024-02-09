namespace IbsRestApi.Entities.IbsMdm;

public partial class IReport4MoneyBook
{
    public IReport4MoneyBook()
    {
        IReport4MoneyBookParameters = new HashSet<IReport4MoneyBookParameter>();
    }

    public int Reportid { get; set; }
    public string? Narration { get; set; }
    public string? Reportfilename { get; set; }
    public string? Runbefore { get; set; }
    public byte? Show4All { get; set; }
    public byte? Show4Gledger { get; set; }
    public byte? Show4CashBook { get; set; }
    public byte? Show4Recon { get; set; }
    public int? IdReportgroup { get; set; }
    public string? Sensitivitylevel { get; set; }

    public virtual ICollection<IReport4MoneyBookParameter> IReport4MoneyBookParameters { get; set; }
}
