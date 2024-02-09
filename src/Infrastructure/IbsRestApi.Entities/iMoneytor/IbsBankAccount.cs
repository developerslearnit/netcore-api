namespace IbsRestApi.Entities.iMoneytor;

public partial class IbsBankAccount
{
    public string IdBankAccount { get; set; } = null!;
    public string? AccountName { get; set; }
    public string? ContactPerson { get; set; }
    public byte? OpenAccount { get; set; }
    public string? BankGlActNo { get; set; }
    public string? ExternalActNo { get; set; }
    public decimal? Balance { get; set; }
    public decimal? UnClearedEffect { get; set; }
    public bool? DormiciliaryAccount { get; set; }
    public decimal? OverDraftLimit { get; set; }
    public DateTime? ExpireDate { get; set; }
    public string? IdCurrency { get; set; }
    public string? IdBank { get; set; }
    public byte? NoOfSignatories { get; set; }
    public string? IdBizUnit { get; set; }
    public bool? CashAccount { get; set; }
    public bool? RequireSecNo { get; set; }
    public int IdSerialNo { get; set; }
    public string? BankGlActNoCcenter { get; set; }
}
