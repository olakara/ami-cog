using AmiCog.Domain.Bill.ValueObjects;
using AmiCog.Domain.Dinner.ValueObjects;
using AmiCog.Domain.Guest.ValueObjects;
using AmiCog.Domain.Host.ValueObjects;
using AmiCog.Domain.Menu.ValueObjects;
using AmiCog.Domain.Models;

namespace AmiCog.Domain.Bill;

public class Bill: AggregateRoot<BillId>
{
    public DinnerId DinnderId { get; }
    public GuestId GuestId { get; }
    public HostId HostId { get; }
    public Price Price { get; }
    public DateTime CreatedDateTime { get;  }
    public DateTime UpdatedDateTime { get; }
    
    private Bill(BillId id, GuestId guestId, HostId hostId, Price price, DateTime createdDateTime, DateTime updatedDateTime) : base(id)
    {
        GuestId = guestId;
        HostId = hostId;
        Price = price;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Bill Create(GuestId guestId, HostId hostId, Price price)
    {
        return new(BillId.CreateUnique(), guestId, hostId, price, DateTime.Now, DateTime.Now);
    }
}