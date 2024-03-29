﻿using AmiCog.Domain.Models;

namespace AmiCog.Domain.Menu.ValueObjects;

public sealed class MenuSectionId : ValueObject
{
    public Guid Value { get; }

    private MenuSectionId(Guid id)
    {
        Value = id;
    }

    public static MenuSectionId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}