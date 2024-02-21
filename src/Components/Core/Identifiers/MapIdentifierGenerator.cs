using System.Numerics;

namespace StellarMap.Core;

public sealed class MapIdentifierGenerator : IIdentifierGenerator
{
    private MapIdentifierGenerator() { }

    public static readonly MapIdentifierGenerator Instance = new();

    public Identifier GenerateIdentifier(StellarObjectType type, IStellarMap? map = null)
    {
        var result = GuardClause.Null(map);
        if (!result.Success) return Identifier.NoIdentifier;

        int count = 0;
        type
            .When(StellarObjectType.Star).Then(() => count = map?.Stars is null ? 0 : map.Stars.Count)
            .When(StellarObjectType.Planet).Then(() => count = map?.Planets is null ? 0 : map.Planets.Count)
            .When(StellarObjectType.DwarfPlanet).Then(() => count = map?.DwarfPlanets is null ? 0 : map.DwarfPlanets.Count)
            .When(StellarObjectType.Satelite).Then(() => count = map?.Satelites is null ? 0 : map.Satelites.Count)
            .When(StellarObjectType.Asteroid).Then(() => count = map?.Asteroids is null ? 0 : map.Asteroids.Count)
            .When(StellarObjectType.Comet).Then(() => count = map?.Comets is null ? 0 : map.Comets.Count);

        return new Identifier($"{type.Name}-{count + 1:D5}");
    }
}
