namespace IbsRestApi.Application.IMoneytor;

public class GenericSPForCalculatingInterest
{
    public decimal? FaceAmount { get; set; }
    public decimal? IntRate { get; set; }
    public string IntMode { get; set; }
    public bool? IntType { get; set; }
    public bool? CapitalisedUpfrontInterest { get; set; }
    public DateTime? EffDate { get; set; }
    public int? Tenor { get; set; }
    public bool? ApplyWTax { get; set; }
    public decimal? EffIntRate { get; set; }
    public DateTime? MaturityDate { get; set; }
    public DateTime? SettlememtDate { get; set; }
    public decimal? BorrowAmount { get; set; }
    public decimal? InterestAmount { get; set; }
    public decimal? WithTax { get; set; }
    public decimal? NetMatValue { get; set; }

}

public class FixedDepositOutputParam
{
    public string EffIntRate { get; set; }
    public DateTime? MaturityDate { get; set; }
    public DateTime? SettlememtDate { get; set; }
    public string EffectiveDate { get; set; }
    public string StrSettlememtDate { get; set; }
    public string BorrowAmount { get; set; }
    public string InterestAmount { get; set; }
    public string WithTax { get; set; }
    public string NetMatValue { get; set; }
    public string ManagementFees { get; set; }
    public string MaturityValue { get; set; }
    public int Tenor { get; set; }
    public string CurrencyId { get; set; }
    public string TransactionFee { get; set; }
    public string TotalFee { get; set; }
}

public class FixedDepositInputParams
{
    public int productID { get; set; }
    public decimal? FaceAmount { get; set; }
    public decimal? BorrowAmt { get; set; }
    public decimal? IntRate { get; set; }
    public decimal? effectIntRate { get; set; }
    public decimal? IntAmount { get; set; }
    public string IntMode { get; set; }
    public bool? IntType { get; set; }
    public bool? CapitalisedUpfrontInterest { get; set; }
    public int Tenor { get; set; }
    public bool? ApplyWTax { get; set; }
    public decimal WhtTaxAmt { get; set; }
    public decimal managementFee { get; set; }
    public string maturityDate { get; set; }
    public DateTime? smaturityDate { get; set; }
    public decimal maturityValue { get; set; }
    public decimal netMaturityValue { get; set; }
    public string currencyID { get; set; }
    public int portfolioContributorId { get; set; }
}
