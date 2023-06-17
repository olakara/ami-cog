using AmiCog.Domain.Bill.ValueObjects;
using AmiCog.Domain.Dinner.ValueObjects;
using AmiCog.Domain.Guest.ValueObjects;
using AmiCog.Domain.MenuReview.ValueObjects;
using AmiCog.Domain.Models;
using AmiCog.Domain.User.ValueObjects;

namespace AmiCog.Domain.Guest;

public class Guest : AggregateRoot<GuestId>
{
    private readonly List<DinnerId> _upcommingDinners = new();
    private readonly List<DinnerId> _pastDinners = new();
    private readonly List<DinnerId> _pendingDinners = new();
    private readonly List<BillId> _bills = new();
    private readonly List<MenuReviewId> _menuReviews = new();

    public string FirstName { get; }
    public string LastName { get;  }
    public string ProfileImage { get; }
    public float AverageRating { get; }
    public UserId UserId { get;  }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    
    // average rating & ratings...
    
    
    public IReadOnlyList<BillId> BillIds => _bills.AsReadOnly();
    public IReadOnlyList<DinnerId> UpCommingDinnerIds => _upcommingDinners.AsReadOnly();
    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinners.AsReadOnly();
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinners.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviews.AsReadOnly();
    
    private Guest(GuestId id,
        string firstName,
        string lastName,
        string image,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = image;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Guest Create(string firstName,
        string lastName,
        string image, UserId userId)
    {
        return new Guest(GuestId.CreateUnique(), firstName, lastName, image, userId, DateTime.Now, DateTime.Now);
    }
}