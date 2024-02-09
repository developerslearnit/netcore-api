namespace IbsRestApi.Entities.iMoneytor;

public partial class SubTable
{
    public int IdSub { get; set; }
    public int? IdTemp { get; set; }
    public DateTime? PayBackDate { get; set; }
    public decimal? PrincipalAmt { get; set; }
}
