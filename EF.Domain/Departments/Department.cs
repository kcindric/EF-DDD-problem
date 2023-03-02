using EF.Domain.Common;
using EF.Domain.Departments.ValueObjects;
using EF.Domain.Municipalities.ValueObjects;
using EF.Domain.Offices.ValueObjects;

namespace EF.Domain.Departments;

public class Department : AggregateRoot<DepartmentId>
{
    private readonly List<MunicipalityId> _municipalityIds = new();

    public string Name { get; private set; }
    public OfficeId OfficeId { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public IReadOnlyList<MunicipalityId> MunicipalityIds => _municipalityIds.AsReadOnly();

    private Department(DepartmentId departmentId, string name, OfficeId officeId, DateTime createdDateTime, DateTime updatedDateTime) :
        base(departmentId)
    {
        Id = departmentId;
        Name = name;
        OfficeId = officeId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Department Create(DepartmentId departmentId, string name, OfficeId officeId)
    {
        return new Department(departmentId, name, officeId,DateTime.UtcNow, DateTime.UtcNow);
    }

    protected Department(){}
}