using AmiCog.Domain.Menu.ValueObjects;
using AmiCog.Domain.Models;

namespace AmiCog.Domain.Guest.ValueObjects;

public class GuestId : ValueObject
{
    public Guid Value { get; }

    private GuestId(Guid id)
    {
        Value = id;
    }

    public static GuestId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
