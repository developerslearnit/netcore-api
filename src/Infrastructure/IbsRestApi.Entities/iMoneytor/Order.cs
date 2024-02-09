namespace IbsRestApi.Entities.iMoneytor;

public partial class Order
{
    public long OrderId { get; set; }
    public string OrderReference { get; set; } = null!;
    public string? Surname { get; set; }
    public string? Othername { get; set; }
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public DateTime? OrderDate { get; set; }
    public string? PaymentReference { get; set; }
    public bool? PaymentStatus { get; set; }
    public string? Bvn { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? IdIdentifyWith { get; set; }
    public string? IdNumber { get; set; }
    public string? NextOfKin { get; set; }
    public string? IdBank { get; set; }
    public string? AccountNo { get; set; }
    public string? IdState { get; set; }
    public bool? ReInvestDividend { get; set; }
    public string? BankAccountName { get; set; }
    public string? Title { get; set; }
    public string? Gender { get; set; }
    public int? Referral { get; set; }
    public DateTime? IdcardIssuedDate { get; set; }
    public DateTime? IdcardExpiredDate { get; set; }
    public int? Tenor { get; set; }
}
