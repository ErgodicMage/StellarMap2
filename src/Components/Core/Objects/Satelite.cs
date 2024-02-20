﻿namespace StellarMap.Core;

public class Satelite : StellarObject
{
    public Satelite() { }

    public Satelite(string name, Identifier identifier, IStellarMap map) : base(name, identifier, map, StellarObjectType.Satelite) { }

    protected override Result<IReadOnlyDictionary<string, Identifier>> GetIdentifiers<T>() => Result.Error(string.Empty);
}
