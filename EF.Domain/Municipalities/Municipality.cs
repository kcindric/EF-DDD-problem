using EF.Domain.Common;
using EF.Domain.Departments.ValueObjects;
using EF.Domain.Municipalities.ValueObjects;

namespace EF.Domain.Municipalities;

public class Municipality : AggregateRoot<MunicipalityId>
{
    public string Name { get; private set; }
    public DepartmentId DepartmentId { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }
    
    private Municipality(MunicipalityId municipalityId, string name,
        DepartmentId departmentId, DateTime createdDateTime, DateTime updatedDateTime)
    {
        Id = municipalityId;
        Name = name;
        DepartmentId = departmentId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Municipality Create(MunicipalityId municipalityId, string name,
        DepartmentId departmentId)
    {
        return new Municipality(municipalityId, name, departmentId, DateTime.UtcNow,
            DateTime.UtcNow);
    }
    
    protected Municipality(){}
}