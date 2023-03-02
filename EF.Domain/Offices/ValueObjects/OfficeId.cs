using EF.Domain.Common;

namespace EF.Domain.Offices.ValueObjects;

public class OfficeId : ValueObject
{
    public int Value { get; }

    private OfficeId(int value)
    {
        Value = value;
    }

    public static OfficeId Create(int value)
    {
        return new OfficeId(value);
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    protected OfficeId(){}
}