using EF.Domain.Common;

namespace EF.Domain.Municipalities.ValueObjects;

public class MunicipalityId : ValueObject
{
    public int Value { get; }

    private MunicipalityId(int value)
    {
        Value = value;
    }

    public static MunicipalityId Create(int value)
    {
        return new MunicipalityId(value);
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    protected MunicipalityId(){}
}