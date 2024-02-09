namespace IbsRestApi.Entities.iMoneytor;

public partial class EqChargesRate
{
    public int IdChargesRate { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public decimal? SecFeesRateBuy { get; set; }
    public bool? VatSecFeesBuy { get; set; }
    public decimal? NseFeesRateBuy { get; set; }
    public bool? VatNseFeesBuy { get; set; }
    public decimal? CscsfeesRateBuy { get; set; }
    public bool? VatCscsfeesBuy { get; set; }
    public decimal? StampDutyRateBuy { get; set; }
    public bool? VatStampDutyBuy { get; set; }
    public decimal? OtherFeesRateBuy { get; set; }
    public bool? VatOtherFeesBuy { get; set; }
    public decimal? SecFeesRateSell { get; set; }
    public bool? VatSecFeesSell { get; set; }
    public decimal? NseFeesRateSell { get; set; }
    public bool? VatNseFeesSell { get; set; }
    public decimal? CscsfeesRateSell { get; set; }
    public bool? VatCscsfeesSell { get; set; }
    public decimal? StampDutyRateSell { get; set; }
    public bool? VatStampDutySell { get; set; }
    public decimal? OtherFeesRateSell { get; set; }
    public bool? VatOtherFeesSell { get; set; }
    public decimal? Provision4LiquidationRate { get; set; }
    public decimal? BrokerComisionRate { get; set; }
    public bool? PaySecFeesNowBuy { get; set; }
    public bool? PayNseFeesNowBuy { get; set; }
    public bool? PayCscsfeesNowBuy { get; set; }
    public bool? PayStampFeesNowBuy { get; set; }
    public bool? PayOtherFeesNowBuy { get; set; }
    public bool? PayVatonFeesNowBuy { get; set; }
    public bool? PayBrokerFeesNowBuy { get; set; }
    public bool? PaySecFeesNowSell { get; set; }
    public bool? PayNseFeesNowSell { get; set; }
    public bool? PayCscsfeesNowSell { get; set; }
    public bool? PayStampFeesNowSell { get; set; }
    public bool? PayOtherFeesNowSell { get; set; }
    public bool? PayVatonFeesNowSell { get; set; }
    public bool? PayBrokerFeesNowSell { get; set; }
    public decimal? AddFixedChargePurchase { get; set; }
    public decimal? AddFixedChargeSell { get; set; }
    public bool? VatBrokerFeesBuy { get; set; }
    public bool? VatBrokerFeesSell { get; set; }
}
