using EF.Domain.Common;

namespace EF.Domain.Departments.ValueObjects;

public class DepartmentId : ValueObject
{
    public int Value { get; }

    private DepartmentId(int value)
    {
        Value = value;
    }

    public static DepartmentId Create(int value)
    {
        return new DepartmentId(value);
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    protected DepartmentId(){}
}