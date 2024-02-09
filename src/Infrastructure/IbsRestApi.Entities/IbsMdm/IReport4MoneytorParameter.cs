﻿namespace IbsRestApi.Entities.IbsMdm;

public partial class IReport4MoneytorParameter
{
    public int IdReportParameter { get; set; }
    public int? ReportId { get; set; }
    public string? ParaName { get; set; }
    public int? ParaType { get; set; }
    public string? ParaDesc { get; set; }
    public bool? AutoAssign { get; set; }
    public string? DefaultValue { get; set; }

    public virtual IReport4Moneytor? Report { get; set; }
}
