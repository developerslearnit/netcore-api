namespace IbsRestApi.Entities.Secure;

public partial class Menu
{
    public Guid IdMenu { get; set; }
    public string IdApplication { get; set; } = null!;
    public string Controller { get; set; } = null!;
    public string Action { get; set; } = null!;
    public string? Area { get; set; }
    public Guid? ParentId { get; set; }
    public bool HasChildren { get; set; }
    public int DisplayOrder { get; set; }
    public string? Icon { get; set; }
    public string MenuText { get; set; } = null!;
    public string DataRoute { get; set; } = null!;
    public bool? IsMenu { get; set; }
}
