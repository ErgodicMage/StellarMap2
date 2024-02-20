namespace StellarMap.Core;

public abstract class StellarObjectType : SmartEnum<StellarObjectType>
{
    public static readonly StellarObjectType Star = new StarType();
    public static readonly StellarObjectType Planet = new PlanetType();
    public static readonly StellarObjectType DwarfPlanet = new DwarfPlanetType();
    public static readonly StellarObjectType Satelite = new SateliteType();
    public static readonly StellarObjectType Asteroid = new AsteroidType();
    public static readonly StellarObjectType Comet = new CometType();

    public Type Type { get; protected init; }



    protected StellarObjectType(string name, int value, Type type) : base(name, value)
    {
        Type = type;
    }

    private sealed class StarType() : StellarObjectType(nameof(Star), 1, typeof(Star))
    {
    }

    private sealed class PlanetType() : StellarObjectType(nameof(Planet), 2, typeof(Planet))
    {
    }

    private sealed class DwarfPlanetType() : StellarObjectType(nameof(DwarfPlanet), 3, typeof(DwarfPlanet))
    {
    }

    private sealed class SateliteType() : StellarObjectType(nameof(Satelite), 4, typeof(Satelite))
    {
    }

    private sealed class AsteroidType() : StellarObjectType(nameof(Asteroid), 5, typeof(Asteroid))
    {
    }

    private sealed class CometType() : StellarObjectType(nameof(Comet), 6, typeof(Comet))
    {
    }
}
