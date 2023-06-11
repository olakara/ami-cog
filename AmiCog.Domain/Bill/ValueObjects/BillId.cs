using AmiCog.Domain.MenuReview.ValueObjects;
using AmiCog.Domain.Models;

namespace AmiCog.Domain.Bill.ValueObjects;

public class BillId : ValueObject
{
    public Guid Value { get; }

    private BillId(Guid id)
    {
        Value = id;
    }

    public static BillId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
