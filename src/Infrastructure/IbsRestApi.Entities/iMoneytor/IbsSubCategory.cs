namespace IbsRestApi.Entities.iMoneytor;

public partial class IbsSubCategory
{
    public string IdSubCategory { get; set; } = null!;
    public string? IdMainCategory { get; set; }
    public string? SubCategory { get; set; }
    public string? GlactNo { get; set; }
    public string? ConGlactNo { get; set; }
    public bool? RequireUcid { get; set; }
    public bool? RequireUsid { get; set; }
    public bool? RequireUeid { get; set; }
    public bool? RequireUtid { get; set; }
    public bool? RequireUpid { get; set; }
    public bool? RequireUqid { get; set; }
    public bool? RequireAcode1 { get; set; }
    public bool? RequireAcode2 { get; set; }
    public bool? RequireAcode3 { get; set; }
    public bool? RequireAcode4 { get; set; }
    public bool? RequireAcode5 { get; set; }
    public string? AccountTreatment { get; set; }
    public int? SofpIdAccountTag { get; set; }
    public int? SoplIdAccountTag { get; set; }
    public int? SocfIdAccountTag { get; set; }
    public int? SocieIdAccountTag { get; set; }
    public int? Usr01IdAccountTag { get; set; }
    public int? Usr02IdAccountTag { get; set; }
    public int? Usr03IdAccountTag { get; set; }
    public int? Usr04IdAccountTag { get; set; }
    public int? Usr05IdAccountTag { get; set; }
    public bool? RequireAcode7 { get; set; }
    public bool? RequireAcode8 { get; set; }
    public bool? RequireAcode9 { get; set; }
    public bool? RequireAcode10 { get; set; }
    public string? TaxCode { get; set; }
    public bool? RequireQtyUnit { get; set; }
    public bool? RequireAcode6 { get; set; }
}
