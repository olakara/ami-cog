﻿using AmiCog.Domain.Menu.ValueObjects;
using AmiCog.Domain.Models;

namespace AmiCog.Domain.User.ValueObjects;

public sealed class UserId : ValueObject
{
    public Guid Value { get; }

    private UserId(Guid id)
    {
        Value = id;
    }

    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}