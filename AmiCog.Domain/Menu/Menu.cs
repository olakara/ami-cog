using AmiCog.Domain.Dinner.ValueObjects;
using AmiCog.Domain.Host.ValueObjects;
using AmiCog.Domain.Menu.Entities;
using AmiCog.Domain.Menu.ValueObjects;
using AmiCog.Domain.MenuReview.ValueObjects;
using AmiCog.Domain.Models;

namespace AmiCog.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    
    public string Name { get; }
    public string Description { get; }
    public float AverageRating { get; }
    public HostId HostId { get; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

    public DateTime CreatedDateTime { get;  }
    public DateTime UpdatedDateTime { get; }
    
    private Menu(MenuId id, 
                string name,
                string description,
                HostId hostId, 
                DateTime createdDateTime, 
                DateTime updatedDateTime) : base(id)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Menu Create(string name, string description, HostId hostId)
    {
        return new(MenuId.CreateUnique(), name, description, hostId, DateTime.Now, DateTime.Now);
    }
}