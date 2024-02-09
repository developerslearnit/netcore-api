namespace IbsRestApi.Application.IMoneytor;

public class BorrowTypeModel
{
    public string IdBorrowType { get; set; }
    public string BorrowType1 { get; set; }
    public string CalculationMethod { get; set; }
    public string BorrowMainActNo { get; set; }
    public string BorrowExpenseActNo { get; set; }
    public string BorrowAccrualActNo { get; set; }
    public bool? TreatAsCall { get; set; }
    public bool? TreatAsTreasuryBill { get; set; }
    public int? Upid { get; set; }
    public int? IdPortfolio { get; set; }
    public decimal? Com1Rate { get; set; }
    public decimal? Com2Rate { get; set; }
    public string IdInvestmentType { get; set; }
    public string IdBizUnit { get; set; }
    public string MgtFeeActNo { get; set; }
    public string BorrowMainActNoCcenter { get; set; }
    public string BorrowExpenseActNoCcenter { get; set; }
    public string BorrowAccrualActNoCcenter { get; set; }
    public string MgtFeeActNoCcenter { get; set; }
    public bool? TreatAsCommercialPaper { get; set; }
    public bool? InterestPaidUpfront { get; set; }
    public bool? CapitaliseUpfrontInterest { get; set; }
    public string TerminationPenaltyType { get; set; }
    public decimal? PenaltyRate { get; set; }
    public decimal? PenaltyFixedAmount { get; set; }
    public decimal? PartialPenaltyRate { get; set; }
    public string PenaltyActNo { get; set; }
    public bool? ApplyWithTax { get; set; }
    public bool? ApplyMgtFees { get; set; }
    public decimal? MgtFeesRate { get; set; }
    public bool? MgtFeesOnInterest { get; set; }
}
