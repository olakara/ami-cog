using AmiCog.Domain.Dinner.ValueObjects;
using AmiCog.Domain.Models;

namespace AmiCog.Domain.MenuReview.ValueObjects;

public class MenuReviewId: ValueObject
{
    public Guid Value { get; }

    private MenuReviewId(Guid id)
    {
        Value = id;
    }

    public static MenuReviewId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
