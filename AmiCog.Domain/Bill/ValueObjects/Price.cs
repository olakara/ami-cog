﻿using AmiCog.Domain.Models;

namespace AmiCog.Domain.Bill.ValueObjects;

public class Price : ValueObject
{
    public decimal Amount { get; private set; }
    public string Currency { get; private set; }

    private Price(decimal amount, string currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public static Price CreateNew(decimal amount, string currency)
    {
        return new(amount, currency);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
}