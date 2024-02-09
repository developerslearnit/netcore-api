namespace IbsRestApi.Application.IMoneytor;

public class BorrowingCalculationDetails
{
    public decimal PrincipalBalance { get; set; }
    public decimal InterestBalance { get; set; }
    public decimal PenaltyAmount { get; set; }
    public decimal SubTotal { get; set; }
    public decimal WithDrawAmount { get; set; }
    public decimal TotalAmount { get; set; }
}
