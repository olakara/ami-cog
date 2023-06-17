using AmiCog.Domain.Bill.ValueObjects;
using AmiCog.Domain.Dinner.Entities;
using AmiCog.Domain.Dinner.Enums;
using AmiCog.Domain.Dinner.ValueObjects;
using AmiCog.Domain.Host.ValueObjects;
using AmiCog.Domain.Menu.ValueObjects;
using AmiCog.Domain.Models;

namespace AmiCog.Domain.Dinner;

public class Dinner: AggregateRoot<DinnerId>
{
    private readonly List<Reservation> _reservations = new();
    public string Name { get; }
    public string Description { get; }
    public DateTime StartDateTime { get;  }
    public DateTime EndDateTime { get; }
    public DateTime StartedDateTime { get;  }
    public DateTime EndedDateTime { get; }
    public bool IsPublic { get; }
    public int MaxGuests { get; }
    public DinnerStatus Status { get; }
    public Price Price { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public string ImageUrl { get; }
    public Location Location { get; set; }
    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

    public DateTime CreatedDateTime { get;  }
    public DateTime UpdatedDateTime { get; }

    private Dinner(
        DinnerId id,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DinnerStatus status,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(id)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Status = status;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
}