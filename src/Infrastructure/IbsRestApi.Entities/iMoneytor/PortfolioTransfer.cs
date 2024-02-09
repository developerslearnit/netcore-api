namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioTransfer
{
    public int IdPortfolioTransfer { get; set; }
    public string? Narration { get; set; }
    public int? FromIdPortfolio { get; set; }
    public decimal? Amount { get; set; }
    public int? ToIdPortfolio { get; set; }
    public DateTime? CaptureDate { get; set; }
    public string? CaptureBy { get; set; }
    public string? ApprovedBy { get; set; }
    public DateTime? ApprovedDate { get; set; }
    public string? Status { get; set; }
    public string? Comments { get; set; }
    public string? VoucherNo { get; set; }
    public bool? Reversed { get; set; }
    public int? ReversalId { get; set; }
    public DateTime? ValueDate { get; set; }
    public decimal? FromBalance { get; set; }
    public decimal? ToBalance { get; set; }
    public decimal? Ex2Rate { get; set; }
    public decimal? Loc2Amount { get; set; }
    public decimal? BidPrice { get; set; }
    public decimal? Units2Sell { get; set; }
    public decimal? OfferPrice { get; set; }
    public decimal? Units2Buy { get; set; }
    public string? IdInvestmentType { get; set; }
    public int? LoanId { get; set; }
    public int? IdDealMaster { get; set; }
    public string? TransferType { get; set; }
}
