namespace StellarMap.Core;

public abstract class StellarObjectType : SmartEnum<StellarObjectType>
{
    public static readonly StellarObjectType Star = new StarType();
    public static readonly StellarObjectType Planet = new PlanetType();
    public static readonly StellarObjectType DwarfPlanet = new DwarfPlanetType();
    public static readonly StellarObjectType Satelite = new SateliteType();
    public static readonly StellarObjectType Asteroid = new AsteroidType();
    public static readonly StellarObjectType Comet = new CometType();

    protected StellarObjectType(string name, int value) : base(name, value)
    { }

    private sealed class StarType() : StellarObjectType(nameof(Star), 1)
    {
    }

    private sealed class PlanetType() : StellarObjectType(nameof(Planet), 2)
    {
    }

    private sealed class DwarfPlanetType() : StellarObjectType(nameof(DwarfPlanet), 3)
    {
    }

    private sealed class SateliteType() : StellarObjectType(nameof(Satelite), 4)
    {
    }

    private sealed class AsteroidType() : StellarObjectType(nameof(Asteroid), 5)
    {
    }

    private sealed class CometType() : StellarObjectType(nameof(Comet), 6)
    {
    }
}
