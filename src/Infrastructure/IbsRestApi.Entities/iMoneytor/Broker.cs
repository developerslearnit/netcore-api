namespace IbsRestApi.Entities.iMoneytor;

public partial class Broker
{
    public int Id { get; set; }
    public string? BrokerId { get; set; }
    public string? Name { get; set; }
    public string? ContactPerson { get; set; }
    public string? Cscsid { get; set; }
    public string? Email { get; set; }
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? IdState { get; set; }
    public string? Telephone1 { get; set; }
    public string? Telephone2 { get; set; }
    public string? FaxNumber { get; set; }
    public string? Director1Name { get; set; }
    public string? Director2Name { get; set; }
    public decimal? BrokerageRate { get; set; }
    public bool? AllowCreditTrade { get; set; }
    public string? BrokerType { get; set; }
    public decimal? SellBrokerageRate { get; set; }
    public string? IdBank { get; set; }
    public string? BankActNo { get; set; }
    public string? BankAddreess { get; set; }
    
    public int? Ucid { get; set; }
}
