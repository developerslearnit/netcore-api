namespace IbsRestApi.Entities.iMoneytor;

public partial class BuildTreasury
{
    public int IdDealAmortSchedule { get; set; }
    public int? IdDealMaster { get; set; }
    public DateTime? DueDate { get; set; }
    public decimal? OpenBalance { get; set; }
    public decimal? RentalAmount { get; set; }
    public decimal? PrnAmount { get; set; }
    public decimal? IntAmount { get; set; }
    public decimal? CloseBalance { get; set; }
    public bool? Posted { get; set; }
    public decimal? IntPerDay { get; set; }
    public bool? Reversed { get; set; }
    public int? ReversalId { get; set; }
    public decimal? CapitalisedPostedInterest { get; set; }
    public decimal? WithTaxAmount { get; set; }
    public bool? CompoundInterest { get; set; }
    public string? UniqueUserId { get; set; }
}
