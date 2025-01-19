using System.Numerics;

namespace StellarMap.Core;

public sealed class MapIdentifierGenerator : IIdentifierGenerator
{
    private MapIdentifierGenerator() { }

    public static readonly MapIdentifierGenerator Instance = new();

    public Identifier GenerateIdentifier(StellarObjectType type, IStellarMap map)
    {
        var result = GuardClause.Null(map);
        if (!result.Success) return Identifier.NoIdentifier;

        var count = map!.GetObjectCount(type);
        if (!count.Success) return Identifier.NoIdentifier;

        return new Identifier($"{type.Name}-{count.Value + 1:D5}");
    }
}
