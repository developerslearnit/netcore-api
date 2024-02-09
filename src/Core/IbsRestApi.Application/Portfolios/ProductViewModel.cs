namespace IbsRestApi.Application.Portfolios;

public class ProductViewModel
{
    public int product_Id { get; set; }

    public string product_name { get; set; }

    public float offerPrice { get; set; } = 0;

    public float bidPrice { get; set; } = 0;

    public decimal yield { get; set; } = 0;

    public decimal minSubAmount { get; set; }

    public bool isUnitBased { get; set; }

    public string currency { get; set; }

    public string product_type { get; set; }
    public string description { get; set; }
    public string borrowTypeId { get; set; }
}


public class PortfolioViewModel
{
    public int product_Id { get; set; }
    public string product_name { get; set; }
    public decimal minSubAmount { get; set; } = 0;
    public string product_type { get; set; }
    public string borrowTypeId { get; set; }
    public string currency { get; set; }

    public bool isUnitBased {
        get {
            return this.product_type == "FIXEDD" ? false : true;
        }
    }

}

public class TenorModel
{
    public int Tenor { get; set; }
    public string key { get { return this.Tenor.ToString(); } }
    public string value { get { return $"{this.Tenor.ToString()} Days"; } }
}