namespace IbsRestApi.Entities.IbsMdm;

public partial class IbsEmployer
{
    public IbsEmployer()
    {
        IbsPeopleEmployers = new HashSet<IbsPeopleEmployer>();
    }

    public string EmployerCode { get; set; } = null!;
    public string? RcNumber { get; set; }
    public string? BusinesName { get; set; }
    public int EmpId { get; set; }

    public virtual ICollection<IbsPeopleEmployer> IbsPeopleEmployers { get; set; }
}
