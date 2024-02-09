namespace IbsRestApi.Entities.iMoneytor;

public partial class IbsRequisitionSplitCheque
{
    public int IdSplitCheque { get; set; }
    public int? IdRequisitionMaster { get; set; }
    public string? Payee { get; set; }
    public string? IdBankAccount { get; set; }
    public string? CheqNo { get; set; }
    public bool? Printed { get; set; }
    public bool? Cancelled { get; set; }
    public decimal? Amount { get; set; }
}
