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

        int count = type.Name switch
        {
            StellarObjectType.STARSYSTEM => map?.StarSystems is null ? 0 : map.StarSystems.Count,
            StellarObjectType.STAR => count = map?.Stars is null ? 0 : map.Stars.Count,
            StellarObjectType.PLANET => map?.Planets is null ? 0 : map.Planets.Count,
            StellarObjectType.DWARFPLANET => map?.DwarfPlanets is null ? 0 : map.DwarfPlanets.Count,
            StellarObjectType.SATELITE => map?.Satelites is null ? 0 : map.Satelites.Count,
            StellarObjectType.ASTEROID => map?.Asteroids is null ? 0 : map.Asteroids.Count,
            StellarObjectType.COMET => map?.Comets is null ? 0 : map.Comets.Count,
            _ => -50001
        };

        return new Identifier($"{type.Name}-{count + 1:D5}");
    }
}
