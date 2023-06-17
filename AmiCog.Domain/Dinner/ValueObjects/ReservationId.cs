using AmiCog.Domain.Host.ValueObjects;
using AmiCog.Domain.Models;

namespace AmiCog.Domain.Dinner.ValueObjects;

public class ReservationId : ValueObject
{
    public Guid Value { get; }

    private ReservationId(Guid id)
    {
        Value = id;
    }

    public static ReservationId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}