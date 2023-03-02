using EF.Domain.Common;
using EF.Domain.Departments.ValueObjects;
using EF.Domain.Offices.ValueObjects;

namespace EF.Domain.Offices;

public class Office : AggregateRoot<OfficeId>
{
    private readonly List<DepartmentId> _departmentIds = new();

    public string Name { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public IReadOnlyList<DepartmentId> DepartmentIds => _departmentIds.AsReadOnly();

    private Office(OfficeId officeId, string name, DateTime createdDateTime, DateTime updatedDateTime) :
        base(officeId)
    {
        Name = name;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Office Create(int officeId, string name)
    {
        return new Office(OfficeId.Create(officeId), name, DateTime.UtcNow, DateTime.UtcNow);
    }
    protected Office(){}
}