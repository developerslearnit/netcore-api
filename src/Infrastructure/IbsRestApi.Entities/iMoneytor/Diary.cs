namespace IbsRestApi.Entities.iMoneytor;

public partial class Diary
{
    public int DiaryId { get; set; }
    public DateTime? Today { get; set; }
    public DateTime? FinYearBegin { get; set; }
    public DateTime? ProcessDate { get; set; }
    public DateTime? FinYearEnd { get; set; }
    public DateTime? MonthEnd { get; set; }
    public DateTime? ValuationDate { get; set; }
    
}
