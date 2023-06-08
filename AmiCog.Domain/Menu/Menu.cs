using AmiCog.Domain.Menu.Entities;
using AmiCog.Domain.Menu.ValueObjects;
using AmiCog.Domain.Models;

namespace AmiCog.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    public string Name { get; }
    public string Description { get; }
    public float AverageRating { get; }
    
    public IReadOnlyList<MenuSection> Sections => _sections;

    public Menu(MenuId id) : base(id)
    {
    }
}