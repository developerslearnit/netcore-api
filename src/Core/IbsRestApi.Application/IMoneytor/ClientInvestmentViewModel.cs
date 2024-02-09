namespace IbsRestApi.Application.IMoneytor;


public class ClientInvestmentDTO
{
    public int ID_ValBrkDwnBr { get; set; }
    public string DatabaseName { get; set; }
    public int ID_Portfolio { get; set; }
    public DateTime ValuationDate { get; set; }
    public string InvestmentModule { get; set; }
    public string Asset { get; set; }
    public string AssetClass { get; set; }
    public decimal AssetValue { get; set; }
    public string Currency { get; set; }
    public decimal Principal { get; set; }
    public decimal IntRate { get; set; }
    public decimal InterestAmount { get; set; }
}

public class ClientInvestmentViewModel
{
    public int ID_ValBrkDwn { get; set; }
    public string DatabaseName { get; set; }
    public int ID_Portfolio { get; set; }
    public DateTime ValuationDate { get; set; }
    public string InvestmentModule { get; set; }
    public string Asset { get; set; }
    public string AssetClass { get; set; }
    public decimal AssetValue { get; set; }
    public string Currency { get; set; }
    public decimal Principal { get; set; }
    public decimal IntRate { get; set;}
    public decimal InterestAmount { get; set; }
}

public class GroupedClientInvestmentViewModel
{

    public int idPortfolio { get; set; }

    public string assetName { get; set; }

    public decimal assetValue { get; set; }

    public string currency { get; set; }

    public decimal cashbalance { get; set; }

    public string investmentModule { get; set; }
    public string databaseName { get; set; }
}
