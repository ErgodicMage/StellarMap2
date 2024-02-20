﻿namespace StellarMap.Core;

public sealed class GuidIdentifierGenerator : IIdentifierGenerator
{
    private GuidIdentifierGenerator() { }

    public Identifier GenerateIdentifier(StellarObjectType type, IStellarMap? _ = null)
        => new ($"{type.Name}-{Guid.NewGuid()}");

    public static readonly GuidIdentifierGenerator Instance = new ();
}
