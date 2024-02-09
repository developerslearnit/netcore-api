namespace IbsRestApi.Entities.iMoneytor;

public partial class PortfolioBenchmarkComputation
{
    public int IdPortfolioBenchmarkComputation { get; set; }
    public int? IdPortfolio { get; set; }
    public DateTime? BeginDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal? Rate { get; set; }
    public int? NoOfDays { get; set; }
    public decimal? Wac { get; set; }
    public DateTime? EoqDate { get; set; }
    public int? LoanTypeId { get; set; }
    
}
