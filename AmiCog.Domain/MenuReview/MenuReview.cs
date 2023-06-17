using AmiCog.Domain.MenuReview.ValueObjects;
using AmiCog.Domain.Models;

namespace AmiCog.Domain.MenuReview;

public class MenuReview : AggregateRoot<MenuReviewId>
{
    public MenuReview(MenuReviewId id) : base(id)
    {
    }
}