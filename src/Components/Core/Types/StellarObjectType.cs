using Ardalis.SmartEnum.SystemTextJson;

namespace StellarMap.Core;

public abstract class StellarObjectType : SmartEnum<StellarObjectType>
{
    public static readonly StellarObjectType StarSystem = new StarSystemType();
    public static readonly StellarObjectType Star = new StarType();
    public static readonly StellarObjectType Planet = new PlanetType();
    public static readonly StellarObjectType DwarfPlanet = new DwarfPlanetType();
    public static readonly StellarObjectType Satelite = new SateliteType();
    public static readonly StellarObjectType Asteroid = new AsteroidType();
    public static readonly StellarObjectType Comet = new CometType();

    public abstract StellarObject CreateObject(string name, Identifier identifier, IStellarMap map);

    protected StellarObjectType(string name, int value) : base(name, value)
    { }

    private sealed class StarSystemType() : StellarObjectType(nameof(StarSystem), 1)
    {
        public override StellarObject CreateObject(string name, Identifier identifier, IStellarMap map)
            => new StarSystem(name, identifier, map);
    }

    private sealed class StarType() : StellarObjectType(nameof(Star), 2)
    {
        public override StellarObject CreateObject(string name, Identifier identifier, IStellarMap map)
            => new Star(name, identifier, map);
    }

    private sealed class PlanetType() : StellarObjectType(nameof(Planet), 3)
    {
        public override StellarObject CreateObject(string name, Identifier identifier, IStellarMap map)
            => new Planet(name, identifier, map);
    }

    private sealed class DwarfPlanetType() : StellarObjectType(nameof(DwarfPlanet), 4)
    {
        public override StellarObject CreateObject(string name, Identifier identifier, IStellarMap map)
            => new DwarfPlanet(name, identifier, map);
    }

    private sealed class SateliteType() : StellarObjectType(nameof(Satelite), 5)
    {
        public override StellarObject CreateObject(string name, Identifier identifier, IStellarMap map)
            => new Satelite(name, identifier, map);
    }

    private sealed class AsteroidType() : StellarObjectType(nameof(Asteroid), 6)
    {
        public override StellarObject CreateObject(string name, Identifier identifier, IStellarMap map)
            => new Asteroid(name, identifier, map);
    }

    private sealed class CometType() : StellarObjectType(nameof(Comet), 7)
    {
        public override StellarObject CreateObject(string name, Identifier identifier, IStellarMap map)
            => new Comet(name, identifier, map);
    }
}

public class StellarObjectTypeConverter : SmartEnumNameConverter<StellarObjectType, int>
{
}
